using System;
using ParqueaderoElDesfalco.Core.Domain;
using Xunit;

namespace ParqueaderoElDesfalco.Core.Test.DomainTests
{
    public class MotorcycleParkingPriceTest
    {
        #region Vars and const of TestClass

        private const int priceOfHour = 500;
        private const int priceOfDay = 4000;
        private const int priceExtraCilindraje = 2000;
        private const int defaultCilindraje = 300;

        private readonly DateTimeOffset defaultDate = DateTimeOffset.Now;
        private readonly string defaultMotorcycleId = "onecarid";

        #endregion

        #region Tests

        [Fact]
        public void MotorcycleParkingInvalidDateTest()
        {
            //Arrange
            DateTimeOffset InvalidDateOfEntry = new DateTimeOffset(2019, 09, 23, 8, 0, 0, new TimeSpan(0, 0, 0));
            DateTimeOffset dateOfDeparture = new DateTimeOffset(2009, 09, 22, 8, 0, 0, new TimeSpan(0, 0, 0));
            int expectedPriceOfParking = 0;
            Motorcycle motorcycle = new Motorcycle(defaultMotorcycleId, InvalidDateOfEntry, defaultCilindraje);

            //Act
            motorcycle.CalculateParkingPrice(dateOfDeparture);

            //Assert
            Assert.Equal(expectedPriceOfParking, motorcycle.ParkingPrice);
        }

        [Fact]
        public void MotorcycleParkingHourPriceTest()
        {
            //Arrange
            int hoursParked = 6;
            DateTimeOffset dateOfDeparture = DateTimeOffset.Now.AddHours(hoursParked);
            int expectedPriceOfParking = hoursParked * priceOfHour;
            Motorcycle motorcycle = new Motorcycle(defaultMotorcycleId, defaultDate, defaultCilindraje);

            //Act
            motorcycle.CalculateParkingPrice(dateOfDeparture);

            //Assert
            Assert.Equal(expectedPriceOfParking, motorcycle.ParkingPrice);
        }

        [Fact]
        public void MotorcycleParkingDayPriceTest()
        {
            //Arrange
            int daysParked = 3;
            DateTimeOffset dateOfDeparture = DateTimeOffset.Now.AddDays(daysParked);
            int expectedPriceOfParking = daysParked * priceOfDay;
            Motorcycle motorcycle = new Motorcycle(defaultMotorcycleId, defaultDate, defaultCilindraje);

            //Act
            motorcycle.CalculateParkingPrice(dateOfDeparture);

            //Assert
            Assert.Equal(expectedPriceOfParking, motorcycle.ParkingPrice);
        }

        [Fact]
        public void MotorcycleParkingHoursAndDaysPriceTest()
        {
            //Arrange
            int daysParked = 2;
            int hoursParked = 8;
            DateTimeOffset dateOfDeparture = DateTimeOffset.Now.AddHours(hoursParked).AddDays(daysParked);
            int expectedPriceOfParking = (hoursParked * priceOfHour) + (daysParked * priceOfDay);
            Motorcycle motorcycle = new Motorcycle(defaultMotorcycleId, defaultDate, defaultCilindraje);

            //Act
            motorcycle.CalculateParkingPrice(dateOfDeparture);

            //Assert
            Assert.Equal(expectedPriceOfParking, motorcycle.ParkingPrice);
        }

        [Fact]
        public void MotorcycleParkingHoursMixedPriceTest()
        {
            //Arrange
            int hoursParked = 17;
            DateTimeOffset dateOfDeparture = DateTimeOffset.Now.AddHours(hoursParked);
            int expectedPriceOfParking = priceOfDay;
            Motorcycle motorcycle = new Motorcycle(defaultMotorcycleId, defaultDate, defaultCilindraje);

            //Act
            motorcycle.CalculateParkingPrice(dateOfDeparture);

            //Assert
            Assert.Equal(expectedPriceOfParking, motorcycle.ParkingPrice);
        }

        [Fact]
        public void MotorcycleHighCilindrajeParkingHourPriceTest()
        {
            //Arrange
            int InvalidCilindraje = 550;
            int hoursParked = 6;
            DateTimeOffset dateOfDeparture = DateTimeOffset.Now.AddHours(hoursParked);
            int expectedPriceOfParking = (hoursParked * priceOfHour) + priceExtraCilindraje;
            Motorcycle motorcycle = new Motorcycle(defaultMotorcycleId, defaultDate, InvalidCilindraje);

            //Act
            motorcycle.CalculateParkingPrice(dateOfDeparture);

            //Assert
            Assert.Equal(expectedPriceOfParking, motorcycle.ParkingPrice);
        }

        [Fact]
        public void MotorcycleHighCilindrajeParkingDaysPriceTest()
        {
            //Arrange
            int InvalidCilindraje = 550;
            int daysParked = 3;
            DateTimeOffset dateOfDeparture = DateTimeOffset.Now.AddDays(daysParked);
            int expectedPriceOfParking = (daysParked * priceOfDay) + priceExtraCilindraje;
            Motorcycle motorcycle = new Motorcycle(defaultMotorcycleId, defaultDate, InvalidCilindraje);

            //Act
            motorcycle.CalculateParkingPrice(dateOfDeparture);

            //Assert
            Assert.Equal(expectedPriceOfParking, motorcycle.ParkingPrice);
        }

        #endregion
    }
}