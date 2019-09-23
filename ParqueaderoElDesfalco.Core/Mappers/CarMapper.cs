using System;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Persistence.Entities;

namespace ParqueaderoElDesfalco.Core.Mappers
{
    public class CarMapper
    {
        public CarMapper(){}

        public Car MapEntityToCar(CarEntity carEntity)
        {
            Car car = new Car();
            car.VehicleId = carEntity.CarId;
            car.DateOfEntry = carEntity.DateOfEntry;
            return car;
        }

        public CarEntity MapCarToEntity(Car car)
        {
            CarEntity carEntity = new CarEntity();
            carEntity.CarId = car.VehicleId;
            carEntity.DateOfEntry = car.DateOfEntry;
            return carEntity;
        }
    }
}
