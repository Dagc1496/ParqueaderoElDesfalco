using System;
using System.Text.RegularExpressions;

namespace ParqueaderoElDesfalco.Core.Domain.DomainObjects
{
    public class Motorcycle : Vehicle
    {
        private const int costPerHour = 500;
        private const int costPerDay = 4000;
        private const int extraCostByCilindraje = 2000;
        private const int limitOfCilindraje = 500;
        private static string motortcycleIdFormat = "[A-Z|a-z]{3}-([0-9]{2}|[0-9]{2}[a-z|A-Z]{1})";


        public int Cilindraje { get; private set; }

        public Motorcycle(string vehicleId, DateTimeOffset dateOfEntry, int cilindraje)
            :base(vehicleId, dateOfEntry, motortcycleIdFormat)
        {
            Cilindraje = cilindraje;
        }

        public override void CalculateParkingPrice(DateTimeOffset dateOfDeparture)
        {
            DateOfDeparture = dateOfDeparture;
            CalculateTimeOfParking();
            int priceOfParking = (HoursOfParking * costPerHour) + (DaysOfParking * costPerDay);
            if (Cilindraje >= limitOfCilindraje)
            {
                priceOfParking += extraCostByCilindraje;
            }
            ParkingPrice = priceOfParking;
        }
    }
}
