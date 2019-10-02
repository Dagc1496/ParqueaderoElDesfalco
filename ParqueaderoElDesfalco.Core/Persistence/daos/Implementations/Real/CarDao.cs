using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Mappers;
using ParqueaderoElDesfalco.Core.Persistence.Entities;

namespace ParqueaderoElDesfalco.Core.Persistence.Daos.Implementations.Real
{
    public class CarDao : ICarDao
    {
        private CarMapper carMapper;

        private readonly IDatabaseManager DatabaseManagerObject;

        public CarDao(IDatabaseManager databaseManager)
        {
            DatabaseManagerObject = databaseManager;
            DatabaseManagerObject.InitilizeDB();
            carMapper = new CarMapper();
        }

        public void CreateCar(Car car)
        {
            CarEntity carEntity = carMapper.MapObjectToEntity(car);
            DatabaseManagerObject.SaveOnDB(carEntity);
        }

        public List<Car> GetAllCars()
        {
            List<CarEntity> carEntities = DatabaseManagerObject.GetAllCars();
            List<Car> cars = new List<Car>();
            if (carEntities == null || carEntities.Count == 0)
            {
                return cars;
            }
            foreach (CarEntity carEntity in carEntities)
            {
                Car car = carMapper.MapEntityToObject(carEntity);
                cars.Add(car);
            }
            return cars;
        }

        public void RemoveCar(Car car)
        {
            CarEntity carEntity = carMapper.MapObjectToEntity(car);
            DatabaseManagerObject.RemoveFromDB(carEntity);
        }

        public List<string> GetAllVehicleIds()
        {
            return DatabaseManagerObject.GetAllVehicleIds();
        }
    }
}
