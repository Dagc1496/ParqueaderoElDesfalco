using System;
using System.Text.RegularExpressions;

namespace ParqueaderoElDesfalco.Core.Domain.DomainObjects
{
    public class Car : Vehicle
    {
        private const int costPerHour = 1000;
        private const int costPerDay = 8000;
        private static string carIdFormat = "[A-Z|a-z]{3}[-][0-9]{3}";

        public Car(string vehicleId, DateTimeOffset dateOfEntry)
            : base(vehicleId, dateOfEntry, carIdFormat) { }

        public override void CalculateParkingPrice(DateTimeOffset dateOfDeparture)
        {
            DateOfDeparture = dateOfDeparture;
            CalculateTimeOfParking();
            int priceOfParking = (HoursOfParking * costPerHour) + (DaysOfParking * costPerDay);
            ParkingPrice = priceOfParking;
        }
    }
}
