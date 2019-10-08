using System;
using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain.DomainObjects;
using ParqueaderoElDesfalco.Core.Domain.DomainValidators;
using ParqueaderoElDesfalco.Core.Persistence.Daos;
using Telerik.JustMock;
using Xunit;

namespace ParqueaderoElDesfalco.Core.Test.ValidatorTests
{
    public class ParkingSpaceValidatorTest
    {
        #region Vars and const of TestClass

        private string defaultCarId = "one-00";
        private string defaultMotorcycleId = "one-0";
        private const int defaultMotorcycleCilindraje = 300;
        private const int limitOfCarsParkingLot = 20;
        private const int limitOfMotorcyclesParkingLot = 10;

        private readonly DateTimeOffset defaultDate = DateTimeOffset.Now;
        private List<Car> cars;
        private Car defaultCar;
        private List<Motorcycle> motorcycles;
        private Motorcycle defaultMotorcycle;

        #endregion

        #region Tests

        [Fact]
        public void CarsParkingLotHaveSpaceTest()
        {
            //Arrange
            var carsPakingLot = Mock.Create<ICarDao>();
            cars = new List<Car>();
            Mock.Arrange(() => carsPakingLot.GetAllVehicles()).Returns(cars);
            CarParkingSpaceValidator carParkingSpaceValidator = new CarParkingSpaceValidator(carsPakingLot);

            //Act
            bool isSpaceInParkingLot = carParkingSpaceValidator.IsVehicleSpaceInParkingLot();

            //Assert
            Assert.True(isSpaceInParkingLot);
        }

        [Fact]
        public void CarsParkingLotHaveNoSpaceTest()
        {
            //Arrange
            var carsPakingLot = Mock.Create<ICarDao>();
            PopulateCarsParkingLot(limitOfCarsParkingLot);
            Mock.Arrange(() => carsPakingLot.GetAllVehicles()).Returns(cars);
            CarParkingSpaceValidator carParkingSpaceValidator = new CarParkingSpaceValidator(carsPakingLot);

            //Act
            bool isSpaceInParkingLot = carParkingSpaceValidator.IsVehicleSpaceInParkingLot();

            //Assert
            Assert.False(isSpaceInParkingLot);
        }

        [Fact]
        public void MotorcycleParkingLotHaveSpaceTest()
        {
            //Arrange
            var motorcyclesPakingLot = Mock.Create<IMotorcycleDao>();
            motorcycles = new List<Motorcycle>();
            Mock.Arrange(() => motorcyclesPakingLot.GetAllVehicles()).Returns(motorcycles);
            MotorcycleParkingSpaceValidator motorcycleParkingSpaceValidator = new MotorcycleParkingSpaceValidator(motorcyclesPakingLot);

            //Act
            bool isSpaceInParkingLot = motorcycleParkingSpaceValidator.IsVehicleSpaceInParkingLot();

            //Assert
            Assert.True(isSpaceInParkingLot);
        }

        [Fact]
        public void MotorcycleParkingLotHaveNoSpaceTest()
        {
            //Arrange
            var motorcyclesPakingLot = Mock.Create<IMotorcycleDao>();
            PopulateMotorcycleParkingLot(limitOfMotorcyclesParkingLot);
            Mock.Arrange(() => motorcyclesPakingLot.GetAllVehicles()).Returns(motorcycles);
            MotorcycleParkingSpaceValidator motorcycleParkingSpaceValidator = new MotorcycleParkingSpaceValidator(motorcyclesPakingLot);

            //Act
            bool isSpaceInParkingLot = motorcycleParkingSpaceValidator.IsVehicleSpaceInParkingLot();

            //Assert
            Assert.False(isSpaceInParkingLot);
        }

        #endregion

        #region Class Methods

        private void PopulateCarsParkingLot(int numberOfCars)
        {
            cars = new List<Car>();
            for (int i = 0; i < numberOfCars; i++)
            {
                defaultCarId += i.ToString();
                defaultCar = new Car(defaultCarId,defaultDate);
                cars.Add(defaultCar);
            }
        }

        private void PopulateMotorcycleParkingLot(int numberOfMotorcycles)
        {
            motorcycles = new List<Motorcycle>();
            for (int i = 0; i < numberOfMotorcycles; i++)
            {
                defaultMotorcycleId += i.ToString();
                defaultMotorcycle = new Motorcycle(defaultMotorcycleId, defaultDate, defaultMotorcycleCilindraje);
                motorcycles.Add(defaultMotorcycle);
            }
        }

        #endregion

    }
}