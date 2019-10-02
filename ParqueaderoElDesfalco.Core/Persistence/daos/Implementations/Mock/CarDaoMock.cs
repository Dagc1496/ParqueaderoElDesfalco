﻿using System;
using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain;

namespace ParqueaderoElDesfalco.Core.Persistence.Daos.Implementations.Mock
{
    public class CarDaoMock : ICarDao
    {

        private List<Car> cars;
        private readonly string defaultId = "defaultId";
        private readonly DateTimeOffset defaultDate = DateTimeOffset.Now;
        private List<string> vehicleIds;

        public CarDaoMock()
        {
            cars = new List<Car>();
            vehicleIds = new List<string>();
            Car car = new Car(defaultId, defaultDate);
            cars.Add(car);
        }

        public void CreateCar(Car car)
        {
            vehicleIds.Add(car.VehicleId);
            cars.Add(car);
        }

        public List<Car> GetAllCars()
        {
            return cars;
        }

        public void RemoveCar(Car car)
        {
            vehicleIds.Remove(car.VehicleId);
            cars.Remove(car);
        }

        public List<string> GetAllVehicleIds()
        {
            return vehicleIds;
        }
    }
}
