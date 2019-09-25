using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task CreateMotorcycle(Motorcycle motorcycle)
        {
            MotorcycleEntity motorcycleEntity = MotorcycleMapperObject.MapMotorcycleToEntity(motorcycle);
            await DatabaseManagerObject.SaveOnDB(motorcycleEntity);
        }

        public async Task<List<Motorcycle>> GetAllMotorcycles()
        {
            List<MotorcycleEntity> motorcycleEntities = await DatabaseManagerObject.GetAllMotorcycles();
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

        public async Task RemoveMotorcycle(Motorcycle motorcycle)
        {
            MotorcycleEntity motorcycleEntity = MotorcycleMapperObject.MapMotorcycleToEntity(motorcycle);
            await DatabaseManagerObject.RemoveFromDB(motorcycleEntity);
        }
    }
}