using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain.Models;
using ParqueaderoElDesfalco.Core.Mappers;
using ParqueaderoElDesfalco.Core.Persistence.Entities;

namespace ParqueaderoElDesfalco.Core.Persistence.Daos.Implementations.Real
{
    public class CarDao : ICarDao
    {

        #region Class vars and constants

        private readonly CarMapper carMapper;
        private readonly DatabaseManager databaseManager;

        #endregion

        #region Constructor

        public CarDao()
        {
            databaseManager = new DatabaseManager();
            databaseManager.InitilizeDB();
            carMapper = new CarMapper();
        }

        #endregion

        #region Class methods

        public void CreateCar(Car car)
        {
            CarEntity carEntity = carMapper.MapObjectToEntity(car);
            databaseManager.SaveOnDB(carEntity);
        }

        public List<Car> GetAllVehicles()
        {
            List<CarEntity> carEntities = databaseManager.GetAllVehicles<CarEntity>();
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
            databaseManager.RemoveFromDB(carEntity.GetType().Name, carEntity.CarId);
        }

        #endregion
    }
}
