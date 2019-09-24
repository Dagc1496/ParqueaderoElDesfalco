using System;

namespace ParqueaderoElDesfalco.Core.Domain
{
    public abstract class Vehicle
    {
        public string VehicleId { get; set; }
        public DateTimeOffset DateOfEntry { get; set; }
        public DateTimeOffset DateOfDeparture { get; set; }
        public int ParkingPrice { get; set; }

        public abstract void CalculateParkingPrice(DateTimeOffset dateOfEntry, DateTimeOffset dateOfDeparture);
    }
}