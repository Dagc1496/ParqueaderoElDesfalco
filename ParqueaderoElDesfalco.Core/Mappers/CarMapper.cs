using System;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Persistence.Entities;

namespace ParqueaderoElDesfalco.Core.Mappers
{
    public class CarMapper : IGeneralMapper<Car,CarEntity>
    {
        public Car MapEntityToObject(CarEntity carEntity)
        {
            Car car = new Car(carEntity.CarId,carEntity.DateOfEntry);
            return car;
        }

        public CarEntity MapObjectToEntity(Car car)
        {
            CarEntity carEntity = new CarEntity();
            carEntity.CarId = car.VehicleId;
            carEntity.DateOfEntry = car.DateOfEntry;
            return carEntity;
        }
    }
}