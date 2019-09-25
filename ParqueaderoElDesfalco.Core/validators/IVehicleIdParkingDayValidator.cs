using System;

namespace ParqueaderoElDesfalco.Core.validators
{
    public interface IVehicleIdParkingDayValidator
    {
        bool IsAllowedToPark(string vehicleId, DateTimeOffset dateOfEntry);
    }
}
