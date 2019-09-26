﻿using System;
using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Persistence.Daos;

namespace ParqueaderoElDesfalco.Core.Validators
{
    public class CarParkingSpaceValidator : IVehicleParkingSpaceValidator
    {

        private ICarDao CarDaoObject;

        private readonly int LimitOfCars = 20;

        public CarParkingSpaceValidator(ICarDao carDao)
        {
            CarDaoObject = carDao;
        }

        public bool IsVehicleSpaceInParkingLot()
        {
            List<Car> cars = CarDaoObject.GetAllCars();
            if (cars.Count == LimitOfCars)
            {
                return false;
            }
            return true;
        }
    }
}