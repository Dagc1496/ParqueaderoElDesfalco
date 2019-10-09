using ParqueaderoElDesfalco.Core.Domain.Models;
using ParqueaderoElDesfalco.Core.Domain.DomainValidators;

namespace ParqueaderoElDesfalco.Core.ServiceDomain
{
    public abstract class VehicleServiceDomain
    {

        #region Class vars and constants

        private VehicleIdParkingDayValidator vehicleIdParkingDayValidator;
        protected bool ParkingSpaceInParkingLot;
        protected bool AllowedbyId;
        protected bool IsVehicleValidId;

        #endregion

        #region Protected methods

        protected virtual void CheckPermissionsToPark(Vehicle vehicle)
        {
            IsVehicleValidId = false;
            ParkingSpaceInParkingLot = false;
            AllowedbyId = false;
            if (vehicleIdParkingDayValidator.IsAllowedToPark(vehicle.VehicleId, vehicle.DateOfEntry))
            {
                AllowedbyId = true;
            }
        }

        protected virtual void SetUpValidators(Vehicle vehicle)
        {
            vehicleIdParkingDayValidator = new VehicleIdParkingDayValidator();
        }

        #endregion
    }
}
