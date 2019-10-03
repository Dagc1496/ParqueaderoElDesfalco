using System;
namespace ParqueaderoElDesfalco.Core.Domain.DomainExeptions
{
    public class VehicleIdException : Exception
    {
        public VehicleIdException(string message) : base(message) { }

        public VehicleIdException(){ }
    }
}
