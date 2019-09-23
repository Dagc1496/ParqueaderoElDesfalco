using System;
namespace ParqueaderoElDesfalco.Core.Domain
{
    public abstract class Vehicle
    {
        public string VehicleId { get; set; }
        public DateTimeOffset DateOfEntry { get; set; }
        public DateTimeOffset DateOfDeparture { get; set; }
        public double ParkingPrice { get; set; }

        public abstract double CalculateParkingPrice(DateTimeOffset dateOfEntry, DateTimeOffset dateOfDeparture);
    }
}
