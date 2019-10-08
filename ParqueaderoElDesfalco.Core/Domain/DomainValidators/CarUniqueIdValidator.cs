using System;
using System.Collections.Generic;
using System.Linq;
using ParqueaderoElDesfalco.Core.Domain.DomainObjects;
using ParqueaderoElDesfalco.Core.Persistence.Daos;

namespace ParqueaderoElDesfalco.Core.Domain.DomainValidators
{
    public class CarUniqueIdValidator
    {

        private readonly ICarDao carDao;
        private List<string> carIds;

        public CarUniqueIdValidator(ICarDao carDao)
        {
            this.carDao = carDao;
        }

        public bool IsAValidId(string vehicleId)
        {
            GetAllIdsInParkingLot();
            for (int i = 0; i < carIds.Count; i++)
            {
                if (carIds.ElementAt(i).Equals(vehicleId))
                {
                    return false;
                }
            }
            return true;
        }

        private void GetAllIdsInParkingLot()
        {
            carIds = new List<string>();
            carIds = CollectCarIds(carDao.GetAllVehicles());
        }

        private List<string> CollectCarIds(List<Car> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                string vehicleId = cars.ElementAt(i).VehicleId;
                carIds.Add(vehicleId);
            }
            return carIds;
        }
    }
}
