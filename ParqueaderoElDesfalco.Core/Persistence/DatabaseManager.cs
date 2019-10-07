using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Persistence.Entities;
using Realms;
using System.Linq;

namespace ParqueaderoElDesfalco.Core.Persistence
{
    public class DatabaseManager<T>
    {

        private Realm realmDatabase;
        private List<string> vehicleIds;

        public void InitilizeDB()
        {
            if(realmDatabase == null)
            {
                realmDatabase = Realm.GetInstance();
            }
        }

        public void SaveOnDB(T entity)
        {
            RealmObject realmObject = entity as RealmObject;
            realmDatabase.Write(() =>
            {
                    realmDatabase.Add(realmObject);
            });
        }

        public void RemoveFromDB(string entityName, string vehicleId)
        {
            realmDatabase.Write(() =>
            {
                realmDatabase.Remove(realmDatabase.Find(entityName, vehicleId));
            });
        }

        public List<CarEntity> GetAllCars()
        {
            List<CarEntity> cars = new List<CarEntity>();
            realmDatabase.Write(() => {
                cars = realmDatabase.All<CarEntity>().ToList();
            });
            return cars;
        }

        public List<MotorcycleEntity> GetAllMotorcycles()
        {
            List<MotorcycleEntity> motorcycles = new List<MotorcycleEntity>();
            realmDatabase.Write(() => {
                motorcycles = realmDatabase.All<MotorcycleEntity>().ToList();
            });
            return motorcycles;
        }

        public List<string> GetAllVehicleIds()
        {
            List<MotorcycleEntity> motorcycles = GetAllMotorcycles();
            List<CarEntity> cars = GetAllCars();
            vehicleIds = new List<string>();
            CollectCarIds(cars);
            CollectMotorcycleIds(motorcycles);
            return vehicleIds;
        }

        private void CollectCarIds(List<CarEntity> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                string vehicleId = cars.ElementAt(i).CarId;
                vehicleIds.Add(vehicleId);
            }
        }

        private void CollectMotorcycleIds(List<MotorcycleEntity> motorcycles)
        {
            for (int i = 0; i < motorcycles.Count; i++)
            {
                string vehicleId = motorcycles.ElementAt(i).MotorcycleId;
                vehicleIds.Add(vehicleId);
            }
        }
    }
}
