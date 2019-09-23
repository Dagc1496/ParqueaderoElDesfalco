using System;
namespace ParqueaderoElDesfalco.Core.models
{
    public class Car
    {
        public Car(){}

        public Car(string carId, DateTimeOffset dateOfEntry, DateTimeOffset dateOfDeparture, double parkingPrice)
        {
            this.CarId = carId;
            this.DateOfEntry = dateOfEntry;
            this.DateOfDeparture = dateOfDeparture;
            this.ParkingPrice = parkingPrice;
        }

        public string CarId { get; set; }
        public DateTimeOffset DateOfEntry { get; set; }
        public DateTimeOffset DateOfDeparture { get; set; }
        public double ParkingPrice { get; set; }
    }
}
