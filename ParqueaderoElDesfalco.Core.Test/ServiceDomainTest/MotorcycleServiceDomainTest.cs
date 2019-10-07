using System;
using Autofac;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Persistence.Daos;
using ParqueaderoElDesfalco.Core.ServiceDomain;
using Xunit;

namespace ParqueaderoElDesfalco.Core.Test.ServiceDomainTest
{
    public class MotorcycleServiceDomainTest : BaseServiceDomain
    {
        private readonly DateTimeOffset defaultDate = DateTimeOffset.Now;
        private readonly string defaultCarId = "onecarid";
        private const int defaultCilindraje = 200;
        private IMotorcycleDao motorcycleDao;

        [Fact]
        public void MotorcycleServiceDomainSaveMotorcycleTest()
        {
            //Arrange
            SetDependencies();
            Motorcycle car = new Motorcycle(defaultCarId, defaultDate, defaultCilindraje);
            MotorcycleServiceDomain carServiceDomain = new MotorcycleServiceDomain(motorcycleDao);
            int actualCars = motorcycleDao.GetAllMotorcycles().Count;

            //Act
            carServiceDomain.SaveVechicleOnDb(car);

            //Assert
            Assert.Equal(actualCars + 1, motorcycleDao.GetAllMotorcycles().Count);
        }

        private void SetDependencies()
        {
            motorcycleDao = ConfigureDependencies().Resolve<IMotorcycleDao>();
        }
    }
}
