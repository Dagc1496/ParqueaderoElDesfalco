using System.Collections.Generic;
using System.Threading.Tasks;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Mappers;
using ParqueaderoElDesfalco.Core.Persistence.Entities;

namespace ParqueaderoElDesfalco.Core.Persistence.Daos
{
    public class MotorcycleDao : IMotorcycleDao
    {
        IDatabaseManager _databaseManager;
        MotorcycleMapper motorcycleMapper;

        public MotorcycleDao(IDatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
            _databaseManager.InitilizeDB();
        }

        public async Task CreateMotorcycle(Motorcycle motorcycle)
        {
            motorcycleMapper = new MotorcycleMapper();
            MotorcycleEntity motorcycleEntity = motorcycleMapper.MapMotorcycleToEntity(motorcycle);
            await _databaseManager.SaveOnDB(motorcycleEntity);
        }

        public List<Motorcycle> GetAllMotorcycles()
        {
            List<MotorcycleEntity> motorcycleEntities = _databaseManager.GetAllMotorcycles();
            List<Motorcycle> motorcycles = new List<Motorcycle>();
            if (motorcycleEntities == null || motorcycleEntities.Count == 0)
            {
                //Recordar poner Exception
            }
            else
            {
                motorcycleMapper = new MotorcycleMapper();
                foreach (MotorcycleEntity motorcycleEntity in motorcycleEntities)
                {
                    Motorcycle motorcycle = motorcycleMapper.MapEntityToMotorcycle(motorcycleEntity);
                    motorcycles.Add(motorcycle);
                }
            }
            return motorcycles;
        }

        public async Task RemoveMotorcycle(Motorcycle motorcycle)
        {
            motorcycleMapper = new MotorcycleMapper();
            MotorcycleEntity motorcycleEntity = motorcycleMapper.MapMotorcycleToEntity(motorcycle);
            await _databaseManager.RemoveFromDB(motorcycleEntity);
        }
    }
}