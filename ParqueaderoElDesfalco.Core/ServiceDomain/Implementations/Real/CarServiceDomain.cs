using System;
using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Domain.DomainExeptions;
using ParqueaderoElDesfalco.Core.Domain.DomainValidators;
using ParqueaderoElDesfalco.Core.Persistence.Daos;
using ParqueaderoElDesfalco.Core.Validators;

namespace ParqueaderoElDesfalco.Core.ServiceDomain.Implementations.Real
{
    public class CarServiceDomain : IVehicleServiceDomain<Car>
    {
        private readonly ICarDao CarDao;
        private VehicleIdParkingDayValidator vehicleIdParkingDayValidator;
        private CarParkingSpaceValidator carParkingSpaceValidator;
        private bool ParkingSpaceInParkingLot;
        private bool AllowedbyId;

        public CarServiceDomain(ICarDao carDao)
        {
            CarDao = carDao;
        }

        public void CheckPermissionsToPark(Car vehicle)
        {
            ParkingSpaceInParkingLot = false;
            AllowedbyId = false;
            if (vehicleIdParkingDayValidator.IsAllowedToPark(vehicle.VehicleId, vehicle.DateOfEntry))
            {
                AllowedbyId = true;
            }
            if (carParkingSpaceValidator.IsVehicleSpaceInParkingLot())
            {
                ParkingSpaceInParkingLot = true;
            }
        }

        public List<Car> GetAllVehicles()
        {
            List<Car> cars = CarDao.GetAllCars();
            return cars;
        }

        public void RemoveVechielFromDB(Car vehicle)
        {
            CarDao.RemoveCar(vehicle);
        }

        public void SaveVechicleOnDb(Car vehicle)
        {
            vehicleIdParkingDayValidator = new VehicleIdParkingDayValidator();
            carParkingSpaceValidator = new CarParkingSpaceValidator(CarDao);
            if (!ParkingSpaceInParkingLot)
            {
                throw (new ParkingLotException("No Space"));
            }
            if (!AllowedbyId)
            {
                throw (new VehicleIdException("Not Allowed Day"));
            }
            else
            {
                CarDao.CreateCar(vehicle);
            }
        }
    }
}
