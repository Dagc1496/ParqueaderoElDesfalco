﻿using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain.Models;
namespace ParqueaderoElDesfalco.Core.Persistence.Daos
{
    public interface ICarDao
    {
        void CreateCar(Car car);
        void RemoveCar(Car car);
        List<Car> GetAllVehicles();
    }
}
