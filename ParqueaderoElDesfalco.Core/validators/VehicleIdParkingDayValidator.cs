using System;
namespace ParqueaderoElDesfalco.Core.validators
{
    public class VehicleIdParkingDayValidator : IVehicleIdParkingDayValidator
    {

        private readonly string notAllowedLetter = "A";
        private readonly DayOfWeek[] allowedDays = {DayOfWeek.Monday, DayOfWeek.Sunday};

        public bool IsAllowedToPark(string vehicleId, DateTimeOffset dateOfEntry)
        {
            bool canPark = false;
            string vehicleIdUpperLetters = vehicleId.ToUpper();
            if (vehicleIdUpperLetters.StartsWith(notAllowedLetter))
            {
                for(int i = 0; i < allowedDays.Length; i++)
                {
                    if (dateOfEntry.DayOfWeek == allowedDays[i])
                    {
                        canPark = true;
                        break;
                    }
                }
            }
            return canPark;
        }
    }
}
