using System;

namespace ParqueaderoElDesfalco.Core.Domain.DomainValidators
{
    public class VehicleIdParkingDayValidator
    {
        private readonly string notAllowedLetter = "A";
        private readonly DayOfWeek[] allowedDays = {DayOfWeek.Monday, DayOfWeek.Sunday};

        public bool IsAllowedToPark(string vehicleId, DateTimeOffset dateOfEntry)
        {
            bool canPark = true;
            string vehicleIdUpperLetters = vehicleId.ToUpper();
            if (vehicleIdUpperLetters.StartsWith(notAllowedLetter))
            {
                canPark = checkDaysForNotAllowedVehicleId(dateOfEntry);           
            }
            return canPark;
        }

        private bool checkDaysForNotAllowedVehicleId(DateTimeOffset dateToCheck)
        {
            for (int i = 0; i < allowedDays.Length; i++)
            {
                if (dateToCheck.DayOfWeek == allowedDays[i])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
