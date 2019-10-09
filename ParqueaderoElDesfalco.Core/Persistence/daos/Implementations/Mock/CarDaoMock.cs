using System;
using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain.Models;
namespace ParqueaderoElDesfalco.Core.Persistence.Daos.Implementations.Mock
{
    public class CarDaoMock : ICarDao
    {

        #region Class vars and constants

        private List<Car> cars;
        private readonly string defaultId = "def-000";
        private readonly DateTimeOffset defaultDate = DateTimeOffset.Now;
        private List<string> vehicleIds;

        #endregion

        #region Constructor

        public CarDaoMock()
        {
            cars = new List<Car>();
            vehicleIds = new List<string>();
            Car car = new Car(defaultId, defaultDate);
            cars.Add(car);
        }

        #endregion

        #region Class methods

        public void CreateCar(Car car)
        {
            if (car != null)
            {
                vehicleIds.Add(car.VehicleId);
                cars.Add(car);
            }
        }

        public List<Car> GetAllVehicles()
        {
            return cars;
        }

        public void RemoveCar(Car car)
        {
            if (car != null)
            {
                vehicleIds.Remove(car.VehicleId);
                cars.Remove(car);
            }
        }

        public List<string> GetAllVehicleIds()
        {
            return vehicleIds;
        }

        #endregion
    }
}
