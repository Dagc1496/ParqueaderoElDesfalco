using System;
using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Persistence.Entities;
using Realms;

namespace ParqueaderoElDesfalco.Core.Persistence
{
    public class DatabaseManager
    {

        private Realm realm;

        public DatabaseManager()
        {
            this.realm = InitilizeDB();
        }

        public Realm InitilizeDB()
        {
            if(realm == null)
            {
                return realm = Realm.GetInstance();
            }else
            {
                return realm;
            }
        }

        public void SaveOnDB(MotorcycleEntity motorcycleEntity)
        {
            realm.Write(() =>
                {
                    realm.Add(motorcycleEntity);
                });
        }

        public void SaveOnDB(CarEntity carEntity)
        {
            realm.Write(() =>
            {
                realm.Add(carEntity);
            });
        }

        public void RemoveFromDB(MotorcycleEntity motorcycleEntity)
        {
            realm.Write(() =>
            {
                realm.Remove(motorcycleEntity);
            });
        }

        public void RemoveFromDB(CarEntity carEntity)
        {
            realm.Write(() =>
            {
                realm.Remove(carEntity);
            });
        }

        public List<CarEntity> GetAllCars()
        {
            List<CarEntity> cars = new List<CarEntity>();
            cars = (List<CarEntity>) realm.All<CarEntity>();
            return cars;
        }

        public List<MotorcycleEntity> GetAllMotorcycles()
        {
            List<MotorcycleEntity> motorcycles = new List<MotorcycleEntity>();
            motorcycles = (List<MotorcycleEntity>)realm.All<MotorcycleEntity>();
            return motorcycles;
        }
    }
}
