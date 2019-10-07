using System;
using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Persistence;
using ParqueaderoElDesfalco.Core.Persistence.Daos.Implementations.Real;
using ParqueaderoElDesfalco.Core.Persistence.Entities;
using Telerik.JustMock;
using Xunit;

namespace ParqueaderoElDesfalco.Core.Test.DaoTests
{
    public class MotorcycleDaoTest
    {
        #region Vars and const of TestClass

        private const int defaulCilindraje = 300;
        private string defaultVehicleId = "defaultId";
        private readonly DateTimeOffset defaultDateOfentry = DateTimeOffset.Now;

        private List<MotorcycleEntity> motorcycleEntities;
        private MotorcycleEntity defaultMotorcycleEntity;

        #endregion

        #region Tests

        [Fact]
        public void GetAllMotorcycleFromDbTest()
        {
            //Arrange
            var mockedDb = Mock.Create<DatabaseManager>();
            motorcycleEntities = new List<MotorcycleEntity>();
            Mock.Arrange(() => mockedDb.InitilizeDB()).DoNothing().MustBeCalled();
            Mock.Arrange(() => mockedDb.GetAllMotorcycles()).Returns(motorcycleEntities);

            int numberOfMotorcyclesInParkingLot = 5;
            PopulateMotorcyclesEntitiesList(numberOfMotorcyclesInParkingLot);
            MotorcycleDao motorcycleDao = new MotorcycleDao();

            //Act
            List<Motorcycle> actualResult = motorcycleDao.GetAllMotorcycles();

            //Assert
            Assert.Equal(actualResult.Count, motorcycleEntities.Count);
            Mock.Assert(mockedDb);
        }

        [Fact]
        public void GetCarsFromEmptyDatabase()
        {
            //Arrange
            var mockedDb = Mock.Create<DatabaseManager>();
            motorcycleEntities = new List<MotorcycleEntity>();
            Mock.Arrange(() => mockedDb.InitilizeDB()).DoNothing().MustBeCalled();
            Mock.Arrange(() => mockedDb.GetAllMotorcycles()).Returns(motorcycleEntities);
            MotorcycleDao motorcycleDao = new MotorcycleDao();
            int expectedResult = 0;

            //Act
            List<Motorcycle> actualResult = motorcycleDao.GetAllMotorcycles();

            //Assert
            Assert.Equal(actualResult.Count, expectedResult);
            Mock.Assert(mockedDb);
        }

        [Fact]
        public void DataBaseReturnsNullList()
        {
            //Arrange
            var mockedDb = Mock.Create<DatabaseManager>();

            //We are not initilizing the carEntities List to make GetAllCars Method return null

            Mock.Arrange(() => mockedDb.InitilizeDB()).DoNothing().MustBeCalled();
            Mock.Arrange(() => mockedDb.GetAllMotorcycles()).Returns(motorcycleEntities);
            MotorcycleDao motorcycleDao = new MotorcycleDao();
            int expectedResult = 0;

            //Act
            List<Motorcycle> actualResult = motorcycleDao.GetAllMotorcycles();

            //Assert
            Assert.Equal(actualResult.Count, expectedResult);
            Mock.Assert(mockedDb);
        }

        [Fact]
        public void SaveCarOnDatabase()
        {
            //Arrange
            var mockedDb = Mock.Create<DatabaseManager>();
            motorcycleEntities = new List<MotorcycleEntity>();
            Motorcycle motorcycle = new Motorcycle(defaultVehicleId, defaultDateOfentry, defaulCilindraje);
            Mock.Arrange(() => mockedDb.SaveOnDB(defaultMotorcycleEntity)).IgnoreArguments().DoNothing().MustBeCalled();
            MotorcycleDao motorcycleDao = new MotorcycleDao();

            //Act
            motorcycleDao.CreateMotorcycle(motorcycle);

            //Assert
            Mock.Assert(mockedDb);
        }

        [Fact]
        public void RemoveCarFromDatabase()
        {
            //Arrange
            var mockedDb = Mock.Create<DatabaseManager>();
            motorcycleEntities = new List<MotorcycleEntity>();
            Motorcycle motorcycle = new Motorcycle(defaultVehicleId, defaultDateOfentry, defaulCilindraje);
            Mock.Arrange(() => mockedDb.RemoveFromDB(defaultMotorcycleEntity)).IgnoreArguments().DoNothing().MustBeCalled();
            MotorcycleDao motorcycleDao = new MotorcycleDao();

            //Act
            motorcycleDao.RemoveMotorcycle(motorcycle);

            //Assert
            Mock.Assert(mockedDb);
        }

        #endregion

        #region Class methods

        private void PopulateMotorcyclesEntitiesList(int numberOfCars)
        {
            for (int i = 0; i < numberOfCars; i++)
            {
                defaultVehicleId += i.ToString();
                defaultMotorcycleEntity = new MotorcycleEntity();
                defaultMotorcycleEntity.MotorcycleId = defaultVehicleId;
                defaultMotorcycleEntity.DateOfEntry = defaultDateOfentry;
                motorcycleEntities.Add(defaultMotorcycleEntity);
            }
        }

        #endregion
    }
}
