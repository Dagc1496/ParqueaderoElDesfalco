using System;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Persistence.Entities;

namespace ParqueaderoElDesfalco.Core.Mappers
{
    public class MotorcycleMapper
    {
        public MotorcycleMapper() { }

        public Motorcycle MapEntityToMotorcycle(MotorcycleEntity motorcycleEntity)
        {
            Motorcycle motorcycle = new Motorcycle();
            motorcycle.VehicleId = motorcycleEntity.MotorcycleId;
            motorcycle.DateOfEntry = motorcycleEntity.DateOfEntry;
            return motorcycle;
        }

        public MotorcycleEntity MapMotorcycleToEntity(Motorcycle motorcycle)
        {
            MotorcycleEntity motorcycleEntity = new MotorcycleEntity();
            motorcycleEntity.MotorcycleId = motorcycle.VehicleId;
            motorcycleEntity.DateOfEntry = motorcycle.DateOfEntry;
            return motorcycleEntity;
        }
    }
}
