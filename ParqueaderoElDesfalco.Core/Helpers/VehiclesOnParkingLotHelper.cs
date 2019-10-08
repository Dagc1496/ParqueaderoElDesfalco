using System;
using System.Collections.Generic;
using System.Linq;
using ParqueaderoElDesfalco.Core.Domain.DomainObjects;
using ParqueaderoElDesfalco.Core.Persistence.Daos;

namespace ParqueaderoElDesfalco.Core.Helpers
{
    public class VehiclesOnParkingLotHelper
    {
        private List<string> vehicleIds;
        private readonly ICarDao carDao;
        private readonly IMotorcycleDao motorcycleDao;

        public VehiclesOnParkingLotHelper(ICarDao carDao, IMotorcycleDao motorcycleDao)
        {
            this.carDao = carDao;
            this.motorcycleDao = motorcycleDao;
        }

        public List<string> GetAllVehicleIds()
        {
            List<Motorcycle> motorcycles = motorcycleDao.GetAllVehicles();
            List<Car> cars = carDao.GetAllVehicles();
            vehicleIds = new List<string>();
            CollectCarIds(cars);
            CollectMotorcycleIds(motorcycles);
            return vehicleIds;
        }

        private void CollectCarIds(List<Car> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                string vehicleId = cars.ElementAt(i).VehicleId;
                vehicleIds.Add(vehicleId);
            }
        }

        private void CollectMotorcycleIds(List<Motorcycle> motorcycles)
        {
            for (int i = 0; i < motorcycles.Count; i++)
            {
                string vehicleId = motorcycles.ElementAt(i).VehicleId;
                vehicleIds.Add(vehicleId);
            }
        }
    }
}
