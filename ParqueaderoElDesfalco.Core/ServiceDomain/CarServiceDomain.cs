using System;
using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Domain.DomainExeptions;
using ParqueaderoElDesfalco.Core.Domain.DomainValidators;
using ParqueaderoElDesfalco.Core.Persistence.Daos;
using ParqueaderoElDesfalco.Core.Validators;

namespace ParqueaderoElDesfalco.Core.ServiceDomain
{
    public class CarServiceDomain
    {
        private readonly ICarDao CarDao;
        private VehicleIdParkingDayValidator vehicleIdParkingDayValidator;
        private CarParkingSpaceValidator carParkingSpaceValidator;
        private UniqueVehicleIdValidator uniqueVehicleIdValidator;
        private bool ParkingSpaceInParkingLot;
        private bool AllowedbyId;
        private bool IsVehicleValidId;

        public CarServiceDomain(ICarDao carDao)
        {
            CarDao = carDao;
        }

        private void CheckPermissionsToPark(Car vehicle)
        {
            IsVehicleValidId = false;
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
            if (uniqueVehicleIdValidator.IsAValidId(vehicle.VehicleId))
            {
                IsVehicleValidId = true;
            }
        }

        public void CalculatePriceOfPark(Car car, DateTimeOffset vechicleDepartureTiem)
        {
            car.CalculateParkingPrice(vechicleDepartureTiem);
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
            uniqueVehicleIdValidator = new UniqueVehicleIdValidator(CarDao);
            CheckPermissionsToPark(vehicle);
            if (!ParkingSpaceInParkingLot)
            {
                throw (new ParkingLotException("No Space"));
            }
            if (!AllowedbyId)
            {
                throw (new VehicleIdException("Not Allowed Day"));
            }
            if (!IsVehicleValidId)
            {
                throw (new VehicleIdException("Vehicle Id Already Exist"));
            }
            else
            {
                CarDao.CreateCar(vehicle);
            }
        }
    }
}
