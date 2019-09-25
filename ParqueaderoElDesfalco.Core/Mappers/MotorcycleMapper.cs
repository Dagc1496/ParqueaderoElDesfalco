using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Persistence.Entities;

namespace ParqueaderoElDesfalco.Core.Mappers
{
    public class MotorcycleMapper
    {
        public Motorcycle MapEntityToMotorcycle(MotorcycleEntity motorcycleEntity)
        {
            Motorcycle motorcycle = new Motorcycle(motorcycleEntity.MotorcycleId,
                                                    motorcycleEntity.DateOfEntry,
                                                    motorcycleEntity.Cilindraje);
            return motorcycle;
        }

        public MotorcycleEntity MapMotorcycleToEntity(Motorcycle motorcycle)
        {
            MotorcycleEntity motorcycleEntity = new MotorcycleEntity();
            motorcycleEntity.MotorcycleId = motorcycle.VehicleId;
            motorcycleEntity.DateOfEntry = motorcycle.DateOfEntry;
            motorcycleEntity.Cilindraje = motorcycle.Cilindraje;
            return motorcycleEntity;
        }
    }
}
