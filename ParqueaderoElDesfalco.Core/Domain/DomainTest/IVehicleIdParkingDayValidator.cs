using System;

namespace ParqueaderoElDesfalco.Core.Domain.DomainTest
{
    public interface IVehicleIdParkingDayValidator
    {
        bool IsAllowedToPark(string vehicleId, DateTimeOffset dateOfEntry);
    }
}
