using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Persistence.Daos;

namespace ParqueaderoElDesfalco.Core.Validators
{
    public class ParkingSpace : IParkingSpace
    {
        private ICarDao _carDao;
        private IMotorcycleDao _motorcycleDao;

        private readonly int LimitOfCars = 20;
        private readonly int LimitOfMotorcycle = 10;

        public ParkingSpace(ICarDao carDao)
        {
            _carDao = carDao;
        }

        public ParkingSpace(IMotorcycleDao motorcycleDao)
        {
            _motorcycleDao = motorcycleDao;
        }

        public bool IsCarSpaceInParkingLot()
        {
            List<Car> cars = _carDao.GetAllCars();
            if (cars.Count == LimitOfCars) return false;
            return true;
        }

        public bool IsMotorcycleSpaceInParkingLot()
        {
            List<Motorcycle> motorcycles = _motorcycleDao.GetAllMotorcycles();
            if (motorcycles.Count == LimitOfMotorcycle) return false;
            return true;
        }
    }
}
