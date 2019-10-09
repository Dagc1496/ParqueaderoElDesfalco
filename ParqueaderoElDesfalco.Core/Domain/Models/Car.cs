using System;
using System.Text.RegularExpressions;

namespace ParqueaderoElDesfalco.Core.Domain.Models
{
    public class Car : Vehicle
    {

        #region Class vars and constants

        private const int costPerHour = 1000;
        private const int costPerDay = 8000;
        private static string carIdFormat = "[A-Z|a-z]{3}[-][0-9]{3}";

        #endregion

        #region Constructor

        public Car(string vehicleId, DateTimeOffset dateOfEntry)
        : base(vehicleId, dateOfEntry, carIdFormat) { }

        #endregion

        #region Class methods

        public override void CalculateParkingPrice(DateTimeOffset dateOfDeparture)
        {
            DateOfDeparture = dateOfDeparture;
            CalculateTimeOfParking();
            int priceOfParking = (HoursOfParking * costPerHour) + (DaysOfParking * costPerDay);
            ParkingPrice = priceOfParking;
        }

        #endregion
    }
}
