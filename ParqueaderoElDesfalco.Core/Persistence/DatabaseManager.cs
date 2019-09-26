using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Persistence.Entities;
using Realms;
using System.Linq;

namespace ParqueaderoElDesfalco.Core.Persistence
{
    public class DatabaseManager : IDatabaseManager
    {
        private Realm RealmDatabase;

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
                RealmDatabase.Remove(carEntity);
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
    }
}
