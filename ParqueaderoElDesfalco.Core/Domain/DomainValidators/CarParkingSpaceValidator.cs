using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain.Models;
using ParqueaderoElDesfalco.Core.Persistence.Daos;

namespace ParqueaderoElDesfalco.Core.Domain.DomainValidators
{
    public class CarParkingSpaceValidator
    {

        #region Class vars and constants

        private readonly ICarDao carDao;
        private readonly int limitOfCars = 20;

        #endregion

        #region Constructor

        public CarParkingSpaceValidator(ICarDao carDao)
        {
            this.carDao = carDao;
        }

        #endregion

        #region Class methods

        public bool IsVehicleSpaceInParkingLot()
        {
            List<Car> cars = carDao.GetAllVehicles();
            if (cars.Count == limitOfCars)
            {
                return false;
            }
            return true;
        }

        #endregion
    }
}
