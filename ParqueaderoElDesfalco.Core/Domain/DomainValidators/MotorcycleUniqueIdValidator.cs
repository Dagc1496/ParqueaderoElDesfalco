using System.Collections.Generic;
using System.Linq;
using ParqueaderoElDesfalco.Core.Domain.Models;
using ParqueaderoElDesfalco.Core.Persistence.Daos;

namespace ParqueaderoElDesfalco.Core.Domain.DomainValidators
{
    public class MotorcycleUniqueIdValidator
    {

        #region Class vars and constants

        private readonly IMotorcycleDao motorcycleDao;
        private List<string> motorcycleIds;

        #endregion

        #region Constructor

        public MotorcycleUniqueIdValidator(IMotorcycleDao motorcycleDao)
        {
            this.motorcycleDao = motorcycleDao;
        }

        #endregion

        #region Class methods

        public bool IsAValidId(string vehicleId)
        {
            GetAllIdsInParkingLot();
            return !motorcycleIds.Any(vehicleId.Equals);
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

        #endregion
    }
}
