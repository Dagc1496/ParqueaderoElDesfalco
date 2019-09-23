using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Mappers;
using ParqueaderoElDesfalco.Core.Persistence.Entities;

namespace ParqueaderoElDesfalco.Core.Persistence.Daos
{
    public class CarDao : ICarDao
    {
        private CarMapper carMapper;
        private readonly IDatabaseManager _databaseManager;

        public CarDao(IDatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
            _databaseManager.InitilizeDB();
        }

        public async Task CreateCar(Car car)
        {
            carMapper = new CarMapper();
            CarEntity carEntity = carMapper.MapCarToEntity(car);
            await _databaseManager.SaveOnDB(carEntity);
        }

        public List<Car> GetAllCars()
        {
            List<CarEntity> carEntities = _databaseManager.GetAllCars();
            List<Car> cars = new List<Car>();
            if (carEntities == null || carEntities.Count == 0)
            {
                //recordar poner Exeption
            }
            else
            {
                carMapper = new CarMapper();
                foreach (CarEntity carEntity in carEntities)
                {
                    Car car = carMapper.MapEntityToCar(carEntity);
                    cars.Add(car);
                }
            }
            return cars;  
        }

        public async Task RemoveCar(Car car)
        {
            carMapper = new CarMapper();
            CarEntity carEntity = carMapper.MapCarToEntity(car);
            await _databaseManager.RemoveFromDB(carEntity);
        }
    }
}
