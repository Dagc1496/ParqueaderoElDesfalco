using System;
using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Persistence.Entities;

namespace ParqueaderoElDesfalco.Core.Persistence.Daos
{
    public interface ICarDao
    {
        void CreateCar(CarEntity car);
        CarEntity GetCar(string carId);
        List<CarEntity> GetAllCars();
    }
}
