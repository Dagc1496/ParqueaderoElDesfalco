using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Persistence.Daos;

namespace ParqueaderoElDesfalco.Core.Domain.DomainValidators
{
    public class CarParkingSpaceValidator
    {

        private readonly ICarDao carDao;

        private readonly int limitOfCars = 20;

        public CarParkingSpaceValidator(ICarDao carDao)
        {
            this.carDao = carDao;
        }

        public bool IsVehicleSpaceInParkingLot()
        {
            List<Car> cars = carDao.GetAllCars();
            if (cars.Count == limitOfCars)
            {
                return false;
            }
            return true;
        }
    }
}
