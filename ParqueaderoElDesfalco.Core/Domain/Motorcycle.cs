using System;

namespace ParqueaderoElDesfalco.Core.Domain
{
    public class Motorcycle : Vehicle
    {
        private readonly int CostPerHour = 500;
        private readonly int CostPerDay = 4000;
        private readonly int HoursToChargeDay = 9;
        private readonly int ExtraCostByCilindraje = 2000;
        private readonly int LimitOfCilindraje = 500;

        public int Cilindraje { get; set; }

        public override void CalculateParkingPrice(DateTimeOffset dateOfEntry, DateTimeOffset dateOfDeparture)
        {
            int hoursOfParking = GetHoursOfParking(dateOfEntry, dateOfDeparture);
            int daysOfParking = hoursOfParking / 24;
            hoursOfParking -= daysOfParking * 24;
            if (hoursOfParking >= HoursToChargeDay)
            {
                daysOfParking += 1;
                hoursOfParking = 0;
            }
            int priceOfParking = (hoursOfParking * CostPerHour) + (daysOfParking * CostPerDay);
            if (this.Cilindraje >= LimitOfCilindraje) priceOfParking += ExtraCostByCilindraje;
            this.ParkingPrice = priceOfParking;
        }

        private int GetHoursOfParking(DateTimeOffset dateOfEntry, DateTimeOffset dateOfDeparture)
        {
            if (dateOfDeparture <= dateOfEntry) return 0;
            long timeOfEntryInSeconds = dateOfEntry.ToUnixTimeSeconds();
            long timeOfDepartureInSeconds = dateOfDeparture.ToUnixTimeSeconds();
            long secondsOfParking = timeOfDepartureInSeconds - timeOfEntryInSeconds;
            int hoursOfParking = (int)secondsOfParking / 3600;
            return hoursOfParking;
        }
    }
}
