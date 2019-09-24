using System;
using Xunit;

using ParqueaderoElDesfalco.Core.Domain;

namespace ParqueaderoElDesfalco.Core.Test.DomainTests
{
    public class CarParkingPriceTest
    {
        private readonly int PriceOfHour = 1000;
        private readonly int PriceOfDay = 8000;

        [Fact]
        public void CarParkingHourPriceTest()
        {
            //Arrange
            Car car = new Car();
            DateTimeOffset dateOfEntry = DateTimeOffset.Now;
            int hoursParked = 6;
            DateTimeOffset dateOfDeparture = DateTimeOffset.Now.AddHours(hoursParked);
            int expectedPriceOfParking = hoursParked * PriceOfHour;

            //Act
            car.CalculateParkingPrice(dateOfEntry,dateOfDeparture);

            //Assert
            Assert.Equal(expectedPriceOfParking , car.ParkingPrice);
        }

        [Fact]
        public void CarParkingDayPriceTest()
        {
            //Arrange
            Car car = new Car();
            DateTimeOffset dateOfEntry = DateTimeOffset.Now;
            int daysParked = 2;
            DateTimeOffset dateOfDeparture = DateTimeOffset.Now.AddDays(daysParked);
            int expectedPriceOfParking = daysParked * PriceOfDay;

            //Act
            car.CalculateParkingPrice(dateOfEntry, dateOfDeparture);

            //Assert
            Assert.Equal(expectedPriceOfParking , car.ParkingPrice);
        }

        [Fact]
        public void CarParkingHoursAndDaysPriceTest()
        {
            //Arrange
            Car car = new Car();
            DateTimeOffset dateOfEntry = DateTimeOffset.Now;
            int daysParked = 2;
            int hoursParked = 6;
            DateTimeOffset dateOfDeparture = DateTimeOffset.Now.AddDays(daysParked).AddHours(hoursParked);
            int expectedPriceOfParking = (daysParked * PriceOfDay) + (hoursParked * PriceOfHour);

            //Act
            car.CalculateParkingPrice(dateOfEntry, dateOfDeparture);

            //Assert
            Assert.Equal(expectedPriceOfParking, car.ParkingPrice);
        }

        [Fact]
        public void CarParkingHoursMixedPriceTest()
        {
            //Arrange
            Car car = new Car();
            DateTimeOffset dateOfEntry = DateTimeOffset.Now;
            int hoursParked = 16;
            DateTimeOffset dateOfDeparture = DateTimeOffset.Now.AddHours(hoursParked);
            int expectedPriceOfParking = PriceOfDay;

            //Act
            car.CalculateParkingPrice(dateOfEntry, dateOfDeparture);

            //Assert
            Assert.Equal(expectedPriceOfParking, car.ParkingPrice);
        }
    }
}
