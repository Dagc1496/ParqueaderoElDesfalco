using System;

namespace ParqueaderoElDesfalco.Core.Domain.DomainObjects
{
    public class Motorcycle : Vehicle
    {
        private const int costPerHour = 500;
        private const int costPerDay = 4000;
        private const int extraCostByCilindraje = 2000;
        private const int limitOfCilindraje = 500;

        public int Cilindraje { get; private set; }

        public Motorcycle(string vehicleId, DateTimeOffset dateOfEntry, int cilindraje)
            :base(vehicleId, dateOfEntry)
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
