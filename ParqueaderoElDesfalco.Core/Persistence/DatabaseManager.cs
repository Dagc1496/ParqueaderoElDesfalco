using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Persistence.Entities;
using Realms;
using System.Linq;
using System.Threading.Tasks;

namespace ParqueaderoElDesfalco.Core.Persistence
{
    public class DatabaseManager
    {
        private Realm _realm;

        public DatabaseManager(Realm realm)
        {
            _realm = realm;
        }

        public Realm InitilizeDB()
        {
            if(_realm == null)
            {
                return _realm = Realm.GetInstance();
            }else
            {
                return _realm;
            }
        }

        public async Task SaveOnDB(MotorcycleEntity motorcycleEntity)
        {
            await _realm.WriteAsync(tempAsyncRealm =>
                {
                    tempAsyncRealm.Add(motorcycleEntity);
                });
        }

        public async Task SaveOnDB(CarEntity carEntity)
        {
            await _realm.WriteAsync(tempAsyncRealm =>
            {
                tempAsyncRealm.Add(carEntity);
            });
        }

        public async Task RemoveFromDB(MotorcycleEntity motorcycleEntity)
        {
            await _realm.WriteAsync(tempAsyncRealm =>
            {
                tempAsyncRealm.Remove(motorcycleEntity);
            });
        }

        public async Task RemoveFromDB(CarEntity carEntity)
        {
            await _realm.WriteAsync(tempAsyncRealm =>
            {
                tempAsyncRealm.Remove(carEntity);
            });
        }

        //no estoy seguro de esta implementacion, revisar en debug posibles errores, tales como que los datos no carguen en la vista
        public async Task<List<CarEntity>> GetAllCars()
        {
            List<CarEntity> cars = new List<CarEntity>();
            await _realm.WriteAsync(tempAsyncRealm => {
                cars = tempAsyncRealm.All<CarEntity>().ToList();
            });
            return cars;
        }

        //Same as Upper Method
        public async Task<List<MotorcycleEntity>> GetAllMotorcycles()
        {
            List<MotorcycleEntity> motorcycles = new List<MotorcycleEntity>();
            await _realm.WriteAsync(tempAsyncRealm => {
                motorcycles = tempAsyncRealm.All<MotorcycleEntity>().ToList();
            });
            return motorcycles;
        }
    }
}
