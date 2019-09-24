using System;

namespace ParqueaderoElDesfalco.Core.Domain
{
    public class Car : Vehicle
    {
        private readonly int CostPerHour = 1000;
        private readonly int CostPerDay = 8000;
        private readonly int HoursToChargeDay = 9; 

        public override void CalculateParkingPrice(DateTimeOffset dateOfEntry, DateTimeOffset dateOfDeparture)
        {
            int hoursOfParking = GetHoursOfParking(dateOfEntry,dateOfDeparture);
            int daysOfParking = hoursOfParking / 24;
            hoursOfParking -= daysOfParking * 24;
            if (hoursOfParking >= HoursToChargeDay)
            {
                daysOfParking += 1;
                hoursOfParking = 0;
            }
            int priceOfParking = (hoursOfParking * CostPerHour) + (daysOfParking * CostPerDay);
            this.ParkingPrice = priceOfParking;
        }

        private int GetHoursOfParking(DateTimeOffset dateOfEntry, DateTimeOffset dateOfDeparture)
        {
            long timeOfEntryInSeconds = dateOfEntry.ToUnixTimeSeconds();
            long timeOfDepartureInSeconds = dateOfDeparture.ToUnixTimeSeconds();
            long secondsOfParking = timeOfDepartureInSeconds - timeOfEntryInSeconds;
            int hoursOfParking = (int)secondsOfParking / 3600;
            return hoursOfParking;
        }
    }
}
