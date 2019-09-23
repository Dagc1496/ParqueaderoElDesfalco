using System;
namespace ParqueaderoElDesfalco.Core.Domain
{
    public class Car : Vehicle
    {
        private int CostPerHour = 1000;
        private int CostPerDay = 8000;

        public override double CalculateParkingPrice(DateTimeOffset dateOfEntry, DateTimeOffset dateOfDeparture)
        {
            throw new NotImplementedException();
        }
    }
}
