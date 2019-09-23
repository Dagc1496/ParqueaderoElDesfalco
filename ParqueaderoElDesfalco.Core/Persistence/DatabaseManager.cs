using System;
using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Persistence.Entities;
using Realms;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task SaveOnDB(MotorcycleEntity motorcycleEntity)
        {
            await realm.WriteAsync(tempAsyncRealm =>
                {
                    tempAsyncRealm.Add(motorcycleEntity);
                });
        }

        public async Task SaveOnDB(CarEntity carEntity)
        {
            await realm.WriteAsync(tempAsyncRealm =>
            {
                tempAsyncRealm.Add(carEntity);
            });
        }

        public async Task RemoveFromDB(MotorcycleEntity motorcycleEntity)
        {
            await realm.WriteAsync(tempAsyncRealm =>
            {
                tempAsyncRealm.Remove(motorcycleEntity);
            });
        }

        public async Task RemoveFromDB(CarEntity carEntity)
        {
            await realm.WriteAsync(tempAsyncRealm =>
            {
                tempAsyncRealm.Remove(carEntity);
            });
        }

        //no estoy seguro de esta implementacion, revisar en debug posibles errores, tales como que los datos no carguen en la vista
        public async Task<List<CarEntity>> GetAllCars()
        {
            List<CarEntity> cars = new List<CarEntity>();
            await realm.WriteAsync(tempAsyncRealm => {
                cars = tempAsyncRealm.All<CarEntity>().ToList();
            });
            return cars;
        }

        //Implementar Asyncronicamente
        public async Task<List<MotorcycleEntity>> GetAllMotorcycles()
        {
            List<MotorcycleEntity> motorcycles = new List<MotorcycleEntity>();
            await realm.WriteAsync(tempAsyncRealm => {
                motorcycles = tempAsyncRealm.All<MotorcycleEntity>().ToList();
            });
            return motorcycles;
        }
    }
}
