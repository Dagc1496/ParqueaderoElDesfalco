using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<bool> IsCarSpaceInParkingLot()
        {
            List<Car> cars = await CarDaoObject.GetAllCars();
            if (cars.Count == LimitOfCars) return false;
            return true;
        }

        public async Task<bool> IsMotorcycleSpaceInParkingLot()
        {
            List<Motorcycle> motorcycles = await MotorcycleDaoObject.GetAllMotorcycles();
            if (motorcycles.Count == LimitOfMotorcycle) return false;
            return true;
        }
    }
}
