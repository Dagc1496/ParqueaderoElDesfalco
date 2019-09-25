using System;
using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Persistence.Daos;
using ParqueaderoElDesfalco.Core.Validators;
using Telerik.JustMock;
using Xunit;

namespace ParqueaderoElDesfalco.Core.Test.ValidatorTests
{
    public class ParkingSpaceValidatorTest
    {

        private readonly DateTimeOffset defaultDate = DateTimeOffset.Now;
        private readonly string defaultVehicleId = "onevehicleid";
        private const int defaultMotorcycleCilindraje = 300;

        [Fact]
        public void CarsParkingLotHaveSpaceTest()
        {
            //Arrange
            var carsPakingLot = Mock.Create<ICarDao>();
            List<Car> cars = new List<Car>();
            Mock.Arrange(() => carsPakingLot.GetAllCars()).Returns(cars);
            ParkingSpaceValidator parkingSpaceValidator = new ParkingSpaceValidator(carsPakingLot);

            //Act
            bool isSpaceInParkingLot = parkingSpaceValidator.IsCarSpaceInParkingLot();

            //Assert
            Assert.True(isSpaceInParkingLot);
        }

        [Fact]
        public void CarsParkingLotHaveNoSpaceTest()
        {
            //Arrange
            var carsPakingLot = Mock.Create<ICarDao>();
            List<Car> cars = new List<Car>();
            for (int i = 0; i < 20; i++)
            {
                string carId = defaultVehicleId + i.ToString();
                Car car = new Car(carId, defaultDate);
                cars.Add(car);
            }
            Mock.Arrange(() => carsPakingLot.GetAllCars()).Returns(cars);
            ParkingSpaceValidator parkingSpaceValidator = new ParkingSpaceValidator(carsPakingLot);

            //Act
            bool isSpaceInParkingLot = parkingSpaceValidator.IsCarSpaceInParkingLot();

            //Assert
            Assert.False(isSpaceInParkingLot);
        }

        [Fact]
        public void MotorcycleParkingLotHaveSpaceTest()
        {
            //Arrange
            var motorcyclesPakingLot = Mock.Create<IMotorcycleDao>();
            List<Motorcycle> motorcycles = new List<Motorcycle>();
            Mock.Arrange(() => motorcyclesPakingLot.GetAllMotorcycles()).Returns(motorcycles);
            ParkingSpaceValidator parkingSpaceValidator = new ParkingSpaceValidator(motorcyclesPakingLot);

            //Act
            bool isSpaceInParkingLot = parkingSpaceValidator.IsMotorcycleSpaceInParkingLot();

            //Assert
            Assert.True(isSpaceInParkingLot);
        }

        [Fact]
        public void MotorcycleParkingLotHaveNoSpaceTest()
        {
            //Arrange
            var motorcyclesPakingLot = Mock.Create<IMotorcycleDao>();
            List<Motorcycle> motorcycles = new List<Motorcycle>();
            for (int i = 0; i < 10; i++)
            {
                string motorcycleId = defaultVehicleId + i.ToString();
                Motorcycle motorcycle = new Motorcycle(motorcycleId, defaultDate, defaultMotorcycleCilindraje);
                motorcycles.Add(motorcycle);
            }
            Mock.Arrange(() => motorcyclesPakingLot.GetAllMotorcycles()).Returns(motorcycles);
            ParkingSpaceValidator parkingSpaceValidator = new ParkingSpaceValidator(motorcyclesPakingLot);

            //Act
            bool isSpaceInParkingLot = parkingSpaceValidator.IsMotorcycleSpaceInParkingLot();

            //Assert
            Assert.False(isSpaceInParkingLot);
        }
    }
}