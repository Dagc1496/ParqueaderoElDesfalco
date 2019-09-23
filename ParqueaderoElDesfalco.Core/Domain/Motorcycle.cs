using System;
namespace ParqueaderoElDesfalco.Core.Domain
{
    public class Motorcycle : Vehicle
    {
        private int CostPerHour = 500;
        private int CostPerDay = 4000;

        public override double CalculateParkingPrice(DateTimeOffset dateOfEntry, DateTimeOffset dateOfDeparture)
        {
            throw new NotImplementedException();
        }
    }
}
