using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Persistence.Entities;
using Realms;
using System.Linq;

namespace ParqueaderoElDesfalco.Core.Persistence
{
    public class DatabaseManager : IDatabaseManager
    {

        private Realm RealmDatabase;
        List<string> vehicleIds;

        public DatabaseManager()
        {
            InitilizeDB();
        }

        public void InitilizeDB()
        {
            if(RealmDatabase == null)
            {
                RealmDatabase = Realm.GetInstance();
            }
        }

        public void SaveOnDB(MotorcycleEntity motorcycleEntity)
        {
            RealmDatabase.Write(() =>
            {
                    RealmDatabase.Add(motorcycleEntity);
            });
        }

        public void SaveOnDB(CarEntity carEntity)
        {
            RealmDatabase.Write(() =>
            {
                RealmDatabase.Add(carEntity);
            });
        }

        public void RemoveFromDB(MotorcycleEntity motorcycleEntity)
        {
            RealmDatabase.Write(() =>
            {
                RealmDatabase.Remove(motorcycleEntity);
            });
        }

        public void RemoveFromDB(CarEntity carEntity)
        {
            RealmDatabase.Write(() =>
            {
                RealmDatabase.Remove(RealmDatabase.Find("CarEntity",carEntity.CarId));
            });
        }

        public List<CarEntity> GetAllCars()
        {
            List<CarEntity> cars = new List<CarEntity>();
            RealmDatabase.Write(() => {
                cars = RealmDatabase.All<CarEntity>().ToList();
            });
            return cars;
        }

        public List<MotorcycleEntity> GetAllMotorcycles()
        {
            List<MotorcycleEntity> motorcycles = new List<MotorcycleEntity>();
            RealmDatabase.Write(() => {
                motorcycles = RealmDatabase.All<MotorcycleEntity>().ToList();
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
