using System;

namespace ParqueaderoElDesfalco.Core.Domain.DomainObjects
{
    public abstract class Vehicle
    {

        #region Class vars and constants

        private const int secondsInHour = 3600;
        private const int hoursToChargeDay = 9;
        private const int hoursInDay = 24;
        protected int HoursOfParking;
        protected int DaysOfParking;

        #endregion

        #region Properties

        public string VehicleId { get; private set; }

        public DateTimeOffset DateOfEntry { get; private set; }

        public DateTimeOffset DateOfDeparture { get; protected set; }

        public int ParkingPrice { get; protected set; }

        #endregion

        #region Constructor

        protected Vehicle(string vehicleId, DateTimeOffset dateOfEntry)
        {
            VehicleId = vehicleId;
            DateOfEntry = dateOfEntry;
        }

        #endregion

        #region Class methdos

        protected void CalculateTimeOfParking()
        {
            CalculateHoursOfParking();
            DaysOfParking = HoursOfParking / hoursInDay;
            HoursOfParking -= DaysOfParking * hoursInDay;
            if (HoursOfParking >= hoursToChargeDay)
            {
                DaysOfParking += 1;
                HoursOfParking = 0;
            }
        }

        private void CalculateHoursOfParking()
        {
            long timeOfEntryInSeconds = DateOfEntry.ToUnixTimeSeconds();
            long timeOfDepartureInSeconds = DateOfDeparture.ToUnixTimeSeconds();
            long secondsOfParking = timeOfDepartureInSeconds - timeOfEntryInSeconds;
            HoursOfParking = (int)secondsOfParking / secondsInHour;
            if (DateOfDeparture <= DateOfEntry)
            {
                HoursOfParking = 0;
            }
        }

        #endregion

        #region Abstract methods

        public abstract void CalculateParkingPrice(DateTimeOffset dateOfDeparture);

        #endregion
    }
}
