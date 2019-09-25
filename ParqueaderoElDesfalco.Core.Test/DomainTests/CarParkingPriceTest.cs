using System;
using Xunit;

using ParqueaderoElDesfalco.Core.Domain;

namespace ParqueaderoElDesfalco.Core.Test.DomainTests
{
    public class CarParkingPriceTest
    {
        private const int PriceOfHour = 1000;
        private const int PriceOfDay = 8000;

        private readonly DateTimeOffset defaultDate = DateTimeOffset.Now;
        private readonly string defaultCarId = "onecarid";

        [Fact]
        public void CarParkingInvalidDateTest()
        {
            //Arrange
            DateTimeOffset InvalidDateOfEntry = new DateTimeOffset(2019, 09, 23, 8, 0, 0, new TimeSpan(0, 0, 0));
            DateTimeOffset dateOfDeparture = new DateTimeOffset(2000, 09, 23, 8, 0, 0, new TimeSpan(0, 0, 0));
            int expectedPriceOfParking = 0;
            Car car = new Car(defaultCarId,InvalidDateOfEntry);

            //Act
            car.CalculateParkingPrice(dateOfDeparture);

            //Assert
            Assert.Equal(expectedPriceOfParking, car.ParkingPrice);
        }

        [Fact]
        public void CarParkingHourPriceTest()
        {
            //Arrange
            int hoursParked = 6;
            DateTimeOffset dateOfDeparture = DateTimeOffset.Now.AddHours(hoursParked);
            int expectedPriceOfParking = hoursParked * PriceOfHour;
            Car car = new Car(defaultCarId, defaultDate);

            //Act
            car.CalculateParkingPrice(dateOfDeparture);

            //Assert
            Assert.Equal(expectedPriceOfParking , car.ParkingPrice);
        }

        [Fact]
        public void CarParkingDayPriceTest()
        {
            //Arrange
            int daysParked = 2;
            DateTimeOffset dateOfDeparture = DateTimeOffset.Now.AddDays(daysParked);
            int expectedPriceOfParking = daysParked * PriceOfDay;
            Car car = new Car(defaultCarId, defaultDate);

            //Act
            car.CalculateParkingPrice(dateOfDeparture);

            //Assert
            Assert.Equal(expectedPriceOfParking , car.ParkingPrice);
        }

        [Fact]
        public void CarParkingHoursAndDaysPriceTest()
        {
            //Arrange
            int daysParked = 2;
            int hoursParked = 6;
            DateTimeOffset dateOfDeparture = DateTimeOffset.Now.AddDays(daysParked).AddHours(hoursParked);
            int expectedPriceOfParking = (daysParked * PriceOfDay) + (hoursParked * PriceOfHour);
            Car car = new Car(defaultCarId, defaultDate);

            //Act
            car.CalculateParkingPrice(dateOfDeparture);

            //Assert
            Assert.Equal(expectedPriceOfParking, car.ParkingPrice);
        }

        [Fact]
        public void CarParkingHoursMixedPriceTest()
        {
            //Arrange
            int hoursParked = 16;
            DateTimeOffset dateOfDeparture = DateTimeOffset.Now.AddHours(hoursParked);
            int expectedPriceOfParking = PriceOfDay;
            Car car = new Car(defaultCarId, defaultDate);

            //Act
            car.CalculateParkingPrice(dateOfDeparture);

            //Assert
            Assert.Equal(expectedPriceOfParking, car.ParkingPrice);
        }
    }
}
