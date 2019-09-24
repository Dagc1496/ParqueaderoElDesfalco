using System;
using ParqueaderoElDesfalco.Core.Domain;
using Xunit;

namespace ParqueaderoElDesfalco.Core.Test.DomainTests
{
    public class MotorcycleParkingPriceTest
    {

        private readonly int PriceOfHour = 500;
        private readonly int PriceOfDay = 4000;
        private readonly int PriceExtraCilindraje = 2000;

        [Fact]
        public void MotorcycleParkingHourPriceTest()
        {
            //Arrange
            Motorcycle motorcycle = new Motorcycle();
            DateTimeOffset dateOfEntry = DateTimeOffset.Now;
            int hoursParked = 6;
            DateTimeOffset dateOfDeparture = DateTimeOffset.Now.AddHours(hoursParked);
            int expectedPriceOfParking = hoursParked * PriceOfHour;

            //Act
            motorcycle.CalculateParkingPrice(dateOfEntry, dateOfDeparture);

            //Assert
            Assert.Equal(expectedPriceOfParking, motorcycle.ParkingPrice);
        }

        [Fact]
        public void MotorcycleParkingDayPriceTest()
        {
            //Arrange
            Motorcycle motorcycle = new Motorcycle();
            DateTimeOffset dateOfEntry = DateTimeOffset.Now;
            int daysParked = 3;
            DateTimeOffset dateOfDeparture = DateTimeOffset.Now.AddDays(daysParked);
            int expectedPriceOfParking = daysParked * PriceOfDay;

            //Act
            motorcycle.CalculateParkingPrice(dateOfEntry, dateOfDeparture);

            //Assert
            Assert.Equal(expectedPriceOfParking, motorcycle.ParkingPrice);
        }

        [Fact]
        public void MotorcycleParkingHoursAndDaysPriceTest()
        {
            //Arrange
            Motorcycle motorcycle = new Motorcycle();
            DateTimeOffset dateOfEntry = DateTimeOffset.Now;
            int daysParked = 2;
            int hoursParked = 8;
            DateTimeOffset dateOfDeparture = DateTimeOffset.Now.AddHours(hoursParked).AddDays(daysParked);
            int expectedPriceOfParking = (hoursParked * PriceOfHour) + (daysParked * PriceOfDay);

            //Act
            motorcycle.CalculateParkingPrice(dateOfEntry, dateOfDeparture);

            //Assert
            Assert.Equal(expectedPriceOfParking, motorcycle.ParkingPrice);
        }

        [Fact]
        public void MotorcycleParkingHoursMixedPriceTest()
        {
            //Arrange
            Motorcycle motorcycle = new Motorcycle();
            DateTimeOffset dateOfEntry = DateTimeOffset.Now;
            int hoursParked = 17;
            DateTimeOffset dateOfDeparture = DateTimeOffset.Now.AddHours(hoursParked);
            int expectedPriceOfParking = PriceOfDay;

            //Act
            motorcycle.CalculateParkingPrice(dateOfEntry, dateOfDeparture);

            //Assert
            Assert.Equal(expectedPriceOfParking, motorcycle.ParkingPrice);
        }

        [Fact]
        public void MotorcycleHighCilindrajeParkingHourPriceTest()
        {
            //Arrange
            Motorcycle motorcycle = new Motorcycle();
            motorcycle.Cilindraje = 550;
            DateTimeOffset dateOfEntry = DateTimeOffset.Now;
            int hoursParked = 6;
            DateTimeOffset dateOfDeparture = DateTimeOffset.Now.AddHours(hoursParked);
            int expectedPriceOfParking = (hoursParked * PriceOfHour) + PriceExtraCilindraje;

            //Act
            motorcycle.CalculateParkingPrice(dateOfEntry, dateOfDeparture);

            //Assert
            Assert.Equal(expectedPriceOfParking, motorcycle.ParkingPrice);
        }

        [Fact]
        public void MotorcycleHighCilindrajeParkingDaysPriceTest()
        {
            //Arrange
            Motorcycle motorcycle = new Motorcycle();
            motorcycle.Cilindraje = 500;
            DateTimeOffset dateOfEntry = DateTimeOffset.Now;
            int daysParked = 3;
            DateTimeOffset dateOfDeparture = DateTimeOffset.Now.AddDays(daysParked);
            int expectedPriceOfParking = (daysParked * PriceOfDay) + PriceExtraCilindraje;

            //Act
            motorcycle.CalculateParkingPrice(dateOfEntry, dateOfDeparture);

            //Assert
            Assert.Equal(expectedPriceOfParking, motorcycle.ParkingPrice);
        }
    }
}