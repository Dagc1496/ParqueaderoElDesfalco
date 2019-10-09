using System;
using System.Linq;

namespace ParqueaderoElDesfalco.Core.Domain.DomainValidators
{
    public class VehicleIdParkingDayValidator
    {

        #region Class vars and constants

        private readonly string notAllowedLetter = "A";
        private readonly DayOfWeek[] allowedDays = { DayOfWeek.Monday, DayOfWeek.Sunday };
        private string vehicleIdUpperLetters;

        #endregion

        #region Class methods

        public bool IsAllowedToPark(string vehicleId, DateTimeOffset dateOfEntry)
        {
            bool canPark = true;
            vehicleIdUpperLetters = string.Empty;
            if (vehicleId != null)
            {
                vehicleIdUpperLetters = vehicleId.ToUpper();
            }
            if (vehicleIdUpperLetters.StartsWith(notAllowedLetter, StringComparison.CurrentCulture))
            {
                canPark = CheckDaysForNotAllowedVehicleId(dateOfEntry);
            }
            return canPark;
        }

        private bool CheckDaysForNotAllowedVehicleId(DateTimeOffset dateToCheck)
        {
            return allowedDays.Any(x => dateToCheck.DayOfWeek.Equals(x));
        }

        #endregion
    }
}
