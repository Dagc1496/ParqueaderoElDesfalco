using System;
using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Persistence;
using ParqueaderoElDesfalco.Core.Persistence.Daos;
using ParqueaderoElDesfalco.Core.Persistence.Entities;
using Telerik.JustMock;
using Xunit;

namespace ParqueaderoElDesfalco.Core.Test.DaoTests
{
    public class CarDaoTests
    {
        #region Vars and const of TestClass

        private string defaultVehicleId = "defaultId";
        private readonly DateTimeOffset defaultDateOfentry = DateTimeOffset.Now;

        private List<CarEntity> carEntities;
        private CarEntity defaultCarEntity;

        #endregion

        #region Tests

        [Fact]
        public void GetAllCarFromDbTest()
        {
            //Arrange
            var mockedDb = Mock.Create<IDatabaseManager>();
            carEntities = new List<CarEntity>();
            Mock.Arrange(() => mockedDb.InitilizeDB()).DoNothing().MustBeCalled();
            Mock.Arrange(() => mockedDb.GetAllCars()).Returns(carEntities);

            int numberOfCarsInParkingLot = 5;
            PopulateCarEntitiesList(numberOfCarsInParkingLot);
            CarDao carDao = new CarDao(mockedDb);

            //Act
            List<Car> actualResult = carDao.GetAllCars();

            //Assert
            Assert.Equal(actualResult.Count, carEntities.Count);
            Mock.Assert(mockedDb);
        }

        [Fact]
        public void GetCarsFromEmptyDB()
        {
            //Arrange
            var mockedDb = Mock.Create<IDatabaseManager>();
            carEntities = new List<CarEntity>();
            Mock.Arrange(() => mockedDb.InitilizeDB()).DoNothing().MustBeCalled();
            Mock.Arrange(() => mockedDb.GetAllCars()).Returns(carEntities);
            CarDao carDao = new CarDao(mockedDb);
            int expectedResult = 0;

            //Act
            List<Car> actualResult = carDao.GetAllCars();

            //Assert
            Assert.Equal(actualResult.Count, expectedResult);
            Mock.Assert(mockedDb);
        }

        [Fact]
        public void BataBaseReturnsNullList()
        {
            //Arrange
            var mockedDb = Mock.Create<IDatabaseManager>();

            //We are not initilizing the carEntities List to Mock GetAllCars Method as null

            Mock.Arrange(() => mockedDb.InitilizeDB()).DoNothing().MustBeCalled();
            Mock.Arrange(() => mockedDb.GetAllCars()).Returns(carEntities);
            CarDao carDao = new CarDao(mockedDb);
            int expectedResult = 0;

            //Act
            List<Car> actualResult = carDao.GetAllCars();

            //Assert
            Assert.Equal(actualResult.Count, expectedResult);
            Mock.Assert(mockedDb);
        }

        #endregion

        #region Class methods

        private void PopulateCarEntitiesList(int numberOfCars)
        {
            for (int i = 0; i< numberOfCars; i++)
            {
                defaultVehicleId += i.ToString();
                defaultCarEntity = new CarEntity();
                defaultCarEntity.CarId = defaultVehicleId;
                defaultCarEntity.DateOfEntry = defaultDateOfentry;
                carEntities.Add(defaultCarEntity);
            }
        }

        #endregion

    }
}