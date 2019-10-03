using System;
namespace ParqueaderoElDesfalco.Core.Domain.DomainExeptions
{
    public class ParkingLotException : Exception
    {
        public ParkingLotException(string exceptionMessage) : base(exceptionMessage) { }

        public ParkingLotException() { }
    }
}
