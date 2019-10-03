using System;
using System.Collections.Generic;
using System.Linq;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Persistence.Daos;

namespace ParqueaderoElDesfalco.Core.Validators
{
    public class UniqueVehicleIdValidator
    {

        private readonly ICarDao CarDao;
        private readonly IMotorcycleDao MotorcycleDao;
        List<string> vehicleIds;

        public UniqueVehicleIdValidator(ICarDao carDao)
        {
            CarDao = carDao;
        }

        public UniqueVehicleIdValidator(IMotorcycleDao motorcycleDao)
        {
            MotorcycleDao = motorcycleDao;
        }

        public bool IsAValidId(string vehicleId)
        {
            GetAllIdsInParkingLot();
            for(int i = 0; i < vehicleIds.Count; i++)
            {
                if (vehicleIds.ElementAt(i).Equals(vehicleId))
                {
                    return false;
                }
            }
            return true;
        }

        private void GetAllIdsInParkingLot()
        {
            vehicleIds = new List<string>();
            if (CarDao == null)
            {
                vehicleIds = MotorcycleDao.GetAllVehicleIds();
            }
            else
            {
                vehicleIds = CarDao.GetAllVehicleIds();
            }
        }
    }
}
