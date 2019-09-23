using System;
namespace ParqueaderoElDesfalco.Core.models
{
    public class Motorcycle
    {
        public Motorcycle(){}

        public Motorcycle(string motorcycleId, DateTimeOffset dateOfEntry,
                          int cilindraje, DateTimeOffset dateOfDeparture,
                          double parkingPrice)
        {
            this.MotorcycleId = motorcycleId;
            this.Cilindraje = cilindraje;
            this.DateOfEntry = dateOfEntry;
            this.DateOfDeparture = dateOfDeparture;
            this.ParkingPrice = parkingPrice;
        }

        public string MotorcycleId { get; set; }
        public int Cilindraje { get; set; }
        public DateTimeOffset DateOfEntry { get; set; }
        public DateTimeOffset DateOfDeparture { get; set; }
        public double ParkingPrice { get; set; }
    }
}
