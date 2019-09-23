using System;
using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.models.entities;

namespace ParqueaderoElDesfalco.Core.models.daos
{
    public interface IMotorcycleDao
    {
        void CreateMotorcycle(MotorcycleEntity motorcycle);
        MotorcycleEntity GetMotorcycle(string motorcycleId);
        List<MotorcycleEntity> GetAllMotorcycles();
    }
}
