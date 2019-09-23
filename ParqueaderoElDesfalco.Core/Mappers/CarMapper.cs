using System;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Persistence.Entities;

namespace ParqueaderoElDesfalco.Core.Helpers
{
    public class CarMapper
    {
        public CarMapper(){}
    }

    public Car MapCarToEntity(CarEntity carEntity)
    {
        Car car = new Car();
        car.VehicleId = carEntity.CarId;
        car.DateOfEntry = carEntity.DateOfEntry;
        return car;
    }

}
