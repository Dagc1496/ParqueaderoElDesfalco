using System;
using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.models.entities;

namespace ParqueaderoElDesfalco.Core.models.daos
{
    public interface ICarDao
    {
        void CreateCar(CarEntity car);
        CarEntity GetCar(string carId);
        List<CarEntity> GetAllCars();
    }
}
