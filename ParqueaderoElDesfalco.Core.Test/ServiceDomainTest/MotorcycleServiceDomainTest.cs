using System;
using Autofac;
using ParqueaderoElDesfalco.Core.Domain.DomainObjects;
using ParqueaderoElDesfalco.Core.Persistence.Daos;
using ParqueaderoElDesfalco.Core.ServiceDomain;
using Xunit;

namespace ParqueaderoElDesfalco.Core.Test.ServiceDomainTest
{
    public class MotorcycleServiceDomainTest : BaseServiceDomainTest
    {
        private readonly DateTimeOffset defaultDate = DateTimeOffset.Now;
        private readonly string defaultCarId = "one-00";
        private const int defaultCilindraje = 200;
        private IMotorcycleDao motorcycleDao;

        [Fact]
        public void MotorcycleServiceDomainSaveMotorcycleTest()
        {
            //Arrange
            SetDependencies();
            Motorcycle car = new Motorcycle(defaultCarId, defaultDate, defaultCilindraje);
            MotorcycleServiceDomain carServiceDomain = new MotorcycleServiceDomain(motorcycleDao);
            int actualCars = motorcycleDao.GetAllVehicles().Count;

            //Act
            carServiceDomain.SaveVechicleOnDb(car);

            //Assert
            Assert.Equal(actualCars + 1, motorcycleDao.GetAllVehicles().Count);
        }

        private void SetDependencies()
        {
            motorcycleDao = ConfigureDependencies().Resolve<IMotorcycleDao>();
        }
    }
}
