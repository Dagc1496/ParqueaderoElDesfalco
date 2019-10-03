using System;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Persistence.Entities;

namespace ParqueaderoElDesfalco.Core.Mappers
{
    public class CarMapper : IGeneralMapper<Car,CarEntity>
    {
        public Car MapEntityToObject(CarEntity vehicleEntity)
        {
            Car car = new Car(vehicleEntity.CarId, vehicleEntity.DateOfEntry);
            return car;
        }

        public CarEntity MapObjectToEntity(Car vehicleObject)
        {
            CarEntity carEntity = new CarEntity();
            carEntity.CarId = vehicleObject.VehicleId;
            carEntity.DateOfEntry = vehicleObject.DateOfEntry;
            return carEntity;
        }
    }
}
