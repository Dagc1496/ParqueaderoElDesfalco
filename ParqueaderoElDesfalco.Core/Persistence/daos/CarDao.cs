using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Mappers;
using ParqueaderoElDesfalco.Core.Persistence.Entities;

namespace ParqueaderoElDesfalco.Core.Persistence.Daos
{
    public class CarDao : ICarDao
    {
        private CarMapper CarMapperObject;

        private readonly IDatabaseManager DatabaseManagerObject;

        public CarDao(IDatabaseManager DatabaseManager)
        {
            DatabaseManagerObject = DatabaseManager;
            DatabaseManagerObject.InitilizeDB();
            CarMapperObject = new CarMapper();
        }

        public void CreateCar(Car car)
        {
            CarEntity carEntity = CarMapperObject.MapCarToEntity(car);
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
                Car car = CarMapperObject.MapEntityToCar(carEntity);
                cars.Add(car);
            }
            return cars;
        }

        public void RemoveCar(Car car)
        {
            CarEntity carEntity = CarMapperObject.MapCarToEntity(car);
            DatabaseManagerObject.RemoveFromDB(carEntity);
        }
    }
}
