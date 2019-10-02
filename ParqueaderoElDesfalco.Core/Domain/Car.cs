using System;

namespace ParqueaderoElDesfalco.Core.Domain
{
    public class Car : Vehicle
    {
        private const int costPerHour = 1000;
        private const int costPerDay = 8000;

        public Car(string vehicleId, DateTimeOffset dateOfEntry)
            : base(vehicleId, dateOfEntry) { }

        public override void CalculateParkingPrice(DateTimeOffset dateOfDeparture)
        {
            DateOfDeparture = dateOfDeparture;
            CalculateTimeOfParking();
            int priceOfParking = (HoursOfParking * costPerHour) + (DaysOfParking * costPerDay);
            ParkingPrice = priceOfParking;
        }
    }
}
