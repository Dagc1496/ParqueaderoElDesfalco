using System.Collections.Generic;
using System.Linq;
using ParqueaderoElDesfalco.Core.Domain.Models;
using ParqueaderoElDesfalco.Core.Persistence.Daos;

namespace ParqueaderoElDesfalco.Core.Domain.DomainValidators
{
    public class CarUniqueIdValidator
    {

        #region Class vars and constants

        private readonly ICarDao carDao;
        private List<string> carIds;

        #endregion

        #region Constructor

        public CarUniqueIdValidator(ICarDao carDao)
        {
            this.carDao = carDao;
        }

        #endregion

        #region Class methods

        public bool IsAValidId(string vehicleId)
        {
            GetAllIdsInParkingLot();
            return !carIds.Any(vehicleId.Equals);
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

        #endregion
    }
}
