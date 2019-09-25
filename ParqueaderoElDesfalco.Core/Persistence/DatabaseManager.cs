using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Persistence.Entities;
using Realms;
using System.Linq;
using System.Threading.Tasks;

namespace ParqueaderoElDesfalco.Core.Persistence
{
    public class DatabaseManager
    {
        private Realm RealmDatabase;

        public Realm InitilizeDB()
        {
            if(RealmDatabase == null)
            {
                return RealmDatabase = Realm.GetInstance();
            }
            else
            {
                return RealmDatabase;
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

        //Same as Upper Method
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
