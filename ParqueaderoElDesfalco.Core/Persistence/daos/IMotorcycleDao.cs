using System;
using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Persistence.Entities;

namespace ParqueaderoElDesfalco.Core.Persistence.Daos
{
    public interface IMotorcycleDao
    {
        void CreateMotorcycle(MotorcycleEntity motorcycle);
        MotorcycleEntity GetMotorcycle(string motorcycleId);
        List<MotorcycleEntity> GetAllMotorcycles();
    }
}