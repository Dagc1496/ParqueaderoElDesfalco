using System;

namespace ParqueaderoElDesfalco.Core.Domain.DomainValidators
{
    public interface IVehicleIdParkingDayValidator
    {
        bool IsAllowedToPark(string vehicleId, DateTimeOffset dateOfEntry);
    }
}
