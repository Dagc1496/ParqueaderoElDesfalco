using ParqueaderoElDesfalco.Core.Domain.DomainObjects;
using ParqueaderoElDesfalco.Core.Persistence.Entities;

namespace ParqueaderoElDesfalco.Core.Mappers
{
    public class MotorcycleMapper : IGeneralMapper<Motorcycle,MotorcycleEntity>
    {
        public Motorcycle MapEntityToObject(MotorcycleEntity vehicleEntity)
        {
            Motorcycle motorcycle = new Motorcycle(vehicleEntity.MotorcycleId,
                                                    vehicleEntity.DateOfEntry,
                                                    vehicleEntity.Cilindraje);
            return motorcycle;
        }

        public MotorcycleEntity MapObjectToEntity(Motorcycle vehicleObject)
        {
            MotorcycleEntity motorcycleEntity = new MotorcycleEntity();
            motorcycleEntity.MotorcycleId = vehicleObject.VehicleId;
            motorcycleEntity.DateOfEntry = vehicleObject.DateOfEntry;
            motorcycleEntity.Cilindraje = vehicleObject.Cilindraje;
            return motorcycleEntity;
        }
    }
}
