using System;
using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain;

namespace ParqueaderoElDesfalco.Core.Persistence.Daos.Implementations.Mock
{
    public class CarDaoMock : ICarDao
    {

        private List<Car> cars;
        private readonly string defaultId = "defaultId";
        private readonly DateTimeOffset defaultDate = DateTimeOffset.Now; 
        
        public CarDaoMock()
        {
            cars = new List<Car>();
            Car car = new Car(defaultId, defaultDate);
            cars.Add(car);
        }

        public void CreateCar(Car car)
        {
            cars.Add(car);
        }

        public List<Car> GetAllCars()
        {
            return cars;
        }

        public void RemoveCar(Car car)
        {
            cars.Remove(car);
        }
    }
}
