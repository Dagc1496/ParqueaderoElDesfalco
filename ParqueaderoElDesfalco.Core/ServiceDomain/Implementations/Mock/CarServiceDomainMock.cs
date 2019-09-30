using System;
using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain;

namespace ParqueaderoElDesfalco.Core.ServiceDomain.Implementations.Mock
{
    public class CarServiceDomainMock : IVehicleServiceDomain<Car>
    {
        private readonly DateTimeOffset defaultDate = DateTimeOffset.Now;

        private string defaultCarId = "onecarid";
        private const int numberOfCars = 3;

        private Car defaultCar;
        private List<Car> cars;

        public CarServiceDomainMock()
        {
            PopulateCarList();
        }

        public List<Car> GetAllVehicles()
        {
            return cars;
        }

        public void RemoveVechielFromDB(Car vehicle){}

        public void SaveVechicleOnDb(Car vehicle){}

        private void PopulateCarList()
        {
            cars = new List<Car>();
            for (int i = 0; i < numberOfCars; i++)
            {
                defaultCarId += i.ToString();
                defaultCar = new Car(defaultCarId, defaultDate);
                cars.Add(defaultCar);
            }
        }

        public void CheckPermissionsToPark(Car vehicle){}
    }
}
