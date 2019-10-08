using System.Collections.Generic;
using System.Linq;
using ParqueaderoElDesfalco.Core.Helpers;
using ParqueaderoElDesfalco.Core.Persistence.Daos;

namespace ParqueaderoElDesfalco.Core.Domain.DomainValidators
{
    public class UniqueVehicleIdValidator
    {

        private readonly ICarDao carDao;
        private readonly IMotorcycleDao motorcycleDao;
        private List<string> vehicleIds;
        private VehiclesOnParkingLotHelper VehiclesOnParkingLotHelper;

        public UniqueVehicleIdValidator(ICarDao carDao, IMotorcycleDao motorcycleDao)
        {
            this.carDao = carDao;
            this.motorcycleDao = motorcycleDao;
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
            VehiclesOnParkingLotHelper = new VehiclesOnParkingLotHelper(carDao,motorcycleDao);
            vehicleIds = VehiclesOnParkingLotHelper.GetAllVehicleIds();
        }
    }
}
