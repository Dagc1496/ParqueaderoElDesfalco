using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain.Models;
using ParqueaderoElDesfalco.Core.Mappers;
using ParqueaderoElDesfalco.Core.Persistence.Entities;

namespace ParqueaderoElDesfalco.Core.Persistence.Daos.Implementations.Real
{
    public class MotorcycleDao : IMotorcycleDao
    {

        #region Class vars and constants

        private readonly DatabaseManager databaseManager;
        private readonly MotorcycleMapper motorcycleMapper;

        #endregion

        #region Constructor

        public MotorcycleDao()
        {
            databaseManager = new DatabaseManager();
            databaseManager.InitilizeDB();
            motorcycleMapper = new MotorcycleMapper();
        }

        #endregion

        #region Class methods

        public void CreateMotorcycle(Motorcycle motorcycle)
        {
            MotorcycleEntity motorcycleEntity = motorcycleMapper.MapObjectToEntity(motorcycle);
            databaseManager.SaveOnDB(motorcycleEntity);
        }

        public List<Motorcycle> GetAllVehicles()
        {
            List<MotorcycleEntity> motorcycleEntities = databaseManager.GetAllVehicles<MotorcycleEntity>();
            List<Motorcycle> motorcycles = new List<Motorcycle>();
            if (motorcycleEntities == null || motorcycleEntities.Count == 0)
            {
                return motorcycles;
            }
            foreach (MotorcycleEntity motorcycleEntity in motorcycleEntities)
            {
                Motorcycle motorcycle = motorcycleMapper.MapEntityToObject(motorcycleEntity);
                motorcycles.Add(motorcycle);
            }
            return motorcycles;
        }

        public void RemoveMotorcycle(Motorcycle motorcycle)
        {
            MotorcycleEntity motorcycleEntity = motorcycleMapper.MapObjectToEntity(motorcycle);
            databaseManager.RemoveFromDB(motorcycleEntity.GetType().Name, motorcycleEntity.MotorcycleId);
        }

        #endregion
    }
}
