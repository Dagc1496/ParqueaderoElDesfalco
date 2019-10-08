using System.Collections.Generic;
using System.Linq;
using ParqueaderoElDesfalco.Core.Domain.DomainObjects;
using ParqueaderoElDesfalco.Core.Persistence.Daos;

namespace ParqueaderoElDesfalco.Core.Domain.DomainValidators
{
    public class MotorcycleUniqueIdValidator
    {

        private readonly IMotorcycleDao motorcycleDao;
        private List<string> motorcycleIds;

        public MotorcycleUniqueIdValidator(IMotorcycleDao motorcycleDao)
        {
            this.motorcycleDao = motorcycleDao;
        }

        public bool IsAValidId(string vehicleId)
        {
            GetAllIdsInParkingLot();
            for (int i = 0; i < motorcycleIds.Count; i++)
            {
                if (motorcycleIds.ElementAt(i).Equals(vehicleId))
                {
                    return false;
                }
            }
            return true;
        }

        private void GetAllIdsInParkingLot()
        {
            motorcycleIds = new List<string>();
            motorcycleIds = CollectCarIds(motorcycleDao.GetAllVehicles());
        }

        private List<string> CollectCarIds(List<Motorcycle> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                string vehicleId = cars.ElementAt(i).VehicleId;
                motorcycleIds.Add(vehicleId);
            }
            return motorcycleIds;
        }
    }
}
