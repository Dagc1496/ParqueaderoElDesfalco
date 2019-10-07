﻿using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Domain.DomainValidators;

namespace ParqueaderoElDesfalco.Core.ServiceDomain
{
    public abstract class VehicleServiceDomain
    {

        private VehicleIdParkingDayValidator vehicleIdParkingDayValidator;
        private EmojiValidator emojiValidator;
        protected bool ParkingSpaceInParkingLot;
        protected bool AllowedbyId;
        protected bool IsVehicleValidId;
        protected bool HaveEmojis;

        protected virtual void CheckPermissionsToPark(Vehicle vehicle)
        {
            HaveEmojis = false;
            IsVehicleValidId = false;
            ParkingSpaceInParkingLot = false;
            AllowedbyId = false;
            if (vehicleIdParkingDayValidator.IsAllowedToPark(vehicle.VehicleId, vehicle.DateOfEntry))
            {
                AllowedbyId = true;
            }
            if (emojiValidator.VehicleIdHasEmojis(vehicle.VehicleId))
            {
                HaveEmojis = true;
            }
            
        }

        protected virtual void SetUpValidators(Vehicle vehicle)
        {
            vehicleIdParkingDayValidator = new VehicleIdParkingDayValidator();
            emojiValidator = new EmojiValidator();
        }
    }
}
