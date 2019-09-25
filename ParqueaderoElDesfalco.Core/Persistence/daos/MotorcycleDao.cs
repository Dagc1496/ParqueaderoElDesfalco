using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Mappers;
using ParqueaderoElDesfalco.Core.Persistence.Entities;

namespace ParqueaderoElDesfalco.Core.Persistence.Daos
{
    public class MotorcycleDao : IMotorcycleDao
    {
        DatabaseManager DatabaseManagerObject;

        MotorcycleMapper MotorcycleMapperObject;

        public MotorcycleDao()
        {
            DatabaseManagerObject = new DatabaseManager();
            DatabaseManagerObject.InitilizeDB();
            MotorcycleMapperObject = new MotorcycleMapper();
        }

        public void CreateMotorcycle(Motorcycle motorcycle)
        {
            MotorcycleEntity motorcycleEntity = MotorcycleMapperObject.MapMotorcycleToEntity(motorcycle);
            DatabaseManagerObject.SaveOnDB(motorcycleEntity);
        }

        public List<Motorcycle> GetAllMotorcycles()
        {
            List<MotorcycleEntity> motorcycleEntities = DatabaseManagerObject.GetAllMotorcycles();
            List<Motorcycle> motorcycles = new List<Motorcycle>();
            if (motorcycleEntities == null || motorcycleEntities.Count == 0)
            {
                return motorcycles;
            }
            foreach (MotorcycleEntity motorcycleEntity in motorcycleEntities)
            {
                Motorcycle motorcycle = MotorcycleMapperObject.MapEntityToMotorcycle(motorcycleEntity);
                motorcycles.Add(motorcycle);
            }
            return motorcycles; 
        }

        public void RemoveMotorcycle(Motorcycle motorcycle)
        {
            MotorcycleEntity motorcycleEntity = MotorcycleMapperObject.MapMotorcycleToEntity(motorcycle);
            DatabaseManagerObject.RemoveFromDB(motorcycleEntity);
        }
    }
}