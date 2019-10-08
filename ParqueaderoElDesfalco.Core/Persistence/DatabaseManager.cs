using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Persistence.Entities;
using Realms;
using System.Linq;

namespace ParqueaderoElDesfalco.Core.Persistence
{
    public class DatabaseManager
    {

        private Realm realmDatabase;

        public void InitilizeDB()
        {
            if(realmDatabase == null)
            {
                realmDatabase = Realm.GetInstance();
            }
        }

        public void SaveOnDB<T> (T entity) where T: RealmObject
        {
            realmDatabase.Write(() =>
            {
                realmDatabase.Add(entity);
            });
        }

        public void RemoveFromDB(string entityName, string vehicleId)
        {
            realmDatabase.Write(() =>
            {
                realmDatabase.Remove(realmDatabase.Find(entityName, vehicleId));
            });
        }

        public List<T> GetAllVehicles<T>() where T : RealmObject
        {
            List<T> vehicles = new List<T>();
            realmDatabase.Write(() => {
                vehicles = realmDatabase.All<T>().ToList();
            });
            return vehicles;
        }
    }
}
