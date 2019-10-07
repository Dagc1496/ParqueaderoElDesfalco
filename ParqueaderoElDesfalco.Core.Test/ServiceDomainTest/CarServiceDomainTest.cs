using System;
using Autofac;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Persistence.Daos;
using ParqueaderoElDesfalco.Core.ServiceDomain;
using Xunit;

namespace ParqueaderoElDesfalco.Core.Test.ServiceDomainTest
{
    public class CarServiceDomainTest : BaseServiceDomain
    {
        private readonly DateTimeOffset defaultDate = DateTimeOffset.Now;
        private readonly string defaultCarId = "onecarid";
        private ICarDao carDao;

        [Fact]
        public void CarServiceDomainSaveCarTest()
        {
            //Arrange
            SetDependencies();
            Car car = new Car(defaultCarId, defaultDate);
            CarServiceDomain carServiceDomain = new CarServiceDomain(carDao);
            int actualCars = carDao.GetAllCars().Count;

            //Act
            carServiceDomain.SaveVechicleOnDb(car);

            //Assert
            Assert.Equal(actualCars+1, carDao.GetAllCars().Count);
        }

        private void SetDependencies()
        {
            carDao = ConfigureDependencies().Resolve<ICarDao>();
        }
    }
}
