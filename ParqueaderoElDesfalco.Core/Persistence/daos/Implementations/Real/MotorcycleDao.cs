using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Mappers;
using ParqueaderoElDesfalco.Core.Persistence.Entities;

namespace ParqueaderoElDesfalco.Core.Persistence.Daos.Implementations.Real
{
    public class MotorcycleDao : IMotorcycleDao
    {
        private readonly IDatabaseManager DatabaseManager;

        private MotorcycleMapper MotorcycleMapperObject;

        public MotorcycleDao(IDatabaseManager databaseManager)
        {
            DatabaseManager = databaseManager;
            DatabaseManager.InitilizeDB();
            MotorcycleMapperObject = new MotorcycleMapper();
        }

        public void CreateMotorcycle(Motorcycle motorcycle)
        {
            MotorcycleEntity motorcycleEntity = MotorcycleMapperObject.MapObjectToEntity(motorcycle);
            DatabaseManager.SaveOnDB(motorcycleEntity);
        }

        public List<Motorcycle> GetAllMotorcycles()
        {
            List<MotorcycleEntity> motorcycleEntities = DatabaseManager.GetAllMotorcycles();
            List<Motorcycle> motorcycles = new List<Motorcycle>();
            if (motorcycleEntities == null || motorcycleEntities.Count == 0)
            {
                return motorcycles;
            }
            foreach (MotorcycleEntity motorcycleEntity in motorcycleEntities)
            {
                Motorcycle motorcycle = MotorcycleMapperObject.MapEntityToObject(motorcycleEntity);
                motorcycles.Add(motorcycle);
            }
            return motorcycles; 
        }

        public void RemoveMotorcycle(Motorcycle motorcycle)
        {
            MotorcycleEntity motorcycleEntity = MotorcycleMapperObject.MapObjectToEntity(motorcycle);
            DatabaseManager.RemoveFromDB(motorcycleEntity);
        }
    }
}