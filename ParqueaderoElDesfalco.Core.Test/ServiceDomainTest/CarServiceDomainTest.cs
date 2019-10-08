using System;
using Autofac;
using ParqueaderoElDesfalco.Core.Domain.DomainObjects;
using ParqueaderoElDesfalco.Core.Persistence.Daos;
using ParqueaderoElDesfalco.Core.ServiceDomain;
using Xunit;

namespace ParqueaderoElDesfalco.Core.Test.ServiceDomainTest
{
    public class CarServiceDomainTest : BaseServiceDomainTest
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
            int actualCars = carDao.GetAllVehicles().Count;

            //Act
            carServiceDomain.SaveVechicleOnDb(car);

            //Assert
            Assert.Equal(actualCars+1, carDao.GetAllVehicles().Count);
        }

        private void SetDependencies()
        {
            carDao = ConfigureDependencies().Resolve<ICarDao>();
        }
    }
}
