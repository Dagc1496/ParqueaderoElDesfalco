using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Persistence.Daos;

namespace ParqueaderoElDesfalco.Core.Validators
{
    public class ParkingSpaceValidator : IParkingSpaceValidator
    {
        private ICarDao CarDaoObject;
        private IMotorcycleDao MotorcycleDaoObject;

        private readonly int LimitOfCars = 20;
        private readonly int LimitOfMotorcycle = 10;

        public ParkingSpaceValidator(ICarDao carDao)
        {
            CarDaoObject = carDao;
        }

        public ParkingSpaceValidator(IMotorcycleDao motorcycleDao)
        {
            MotorcycleDaoObject = motorcycleDao;
        }

        public bool IsCarSpaceInParkingLot()
        {
            List<Car> cars = CarDaoObject.GetAllCars();
            if (cars.Count == LimitOfCars) return false;
            return true;
        }

        public bool IsMotorcycleSpaceInParkingLot()
        {
            List<Motorcycle> motorcycles = MotorcycleDaoObject.GetAllMotorcycles();
            if (motorcycles.Count == LimitOfMotorcycle) return false;
            return true;
        }
    }
}
