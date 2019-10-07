﻿using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Mappers;
using ParqueaderoElDesfalco.Core.Persistence.Entities;

namespace ParqueaderoElDesfalco.Core.Persistence.Daos.Implementations.Real
{
    public class MotorcycleDao : IMotorcycleDao
    {

        private readonly DatabaseManager<MotorcycleEntity> databaseManager;
        private readonly MotorcycleMapper motorcycleMapper;

        public MotorcycleDao()
        {
            databaseManager = new DatabaseManager<MotorcycleEntity>();
            databaseManager.InitilizeDB();
            motorcycleMapper = new MotorcycleMapper();
        }

        public void CreateMotorcycle(Motorcycle motorcycle)
        {
            MotorcycleEntity motorcycleEntity = motorcycleMapper.MapObjectToEntity(motorcycle);
            databaseManager.SaveOnDB(motorcycleEntity);
        }

        public List<Motorcycle> GetAllMotorcycles()
        {
            List<MotorcycleEntity> motorcycleEntities = databaseManager.GetAllMotorcycles();
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

        public List<string> GetAllVehicleIds()
        {
            return databaseManager.GetAllVehicleIds();
        }
    }
}
