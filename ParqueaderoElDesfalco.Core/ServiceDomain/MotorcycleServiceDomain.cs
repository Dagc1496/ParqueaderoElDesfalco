using System;
using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Domain.DomainExeptions;
using ParqueaderoElDesfalco.Core.Domain.DomainValidators;
using ParqueaderoElDesfalco.Core.Persistence.Daos;
using ParqueaderoElDesfalco.Core.Validators;

namespace ParqueaderoElDesfalco.Core.ServiceDomain
{ 
    public class MotorcycleServiceDomain
    {

        private readonly IMotorcycleDao MotorCycleDao;
        private VehicleIdParkingDayValidator vehicleIdParkingDayValidator;
        private MotorcycleParkingSpaceValidator motorcycleParkingSpaceValidator;
        private UniqueVehicleIdValidator uniqueVehicleIdValidator;
        private bool ParkingSpaceInParkingLot;
        private bool AllowedbyId;
        private bool IsVehicleValidId;

        public MotorcycleServiceDomain(IMotorcycleDao motorCycleDao)
        {
            MotorCycleDao = motorCycleDao;
        }

        public List<Motorcycle> GetAllVehicles()
        {
            List<Motorcycle> motorcycles = MotorCycleDao.GetAllMotorcycles();
            return motorcycles;
        }

        public void CalculatePriceOfPark(Motorcycle motorcycle, DateTimeOffset vehicleDepartureTime)
        {
            motorcycle.CalculateParkingPrice(vehicleDepartureTime);
        }

        public void RemoveVechielFromDB(Motorcycle vehicle)
        {
            MotorCycleDao.RemoveMotorcycle(vehicle);
        }

        public void SaveVechicleOnDb(Motorcycle vehicle)
        {
            vehicleIdParkingDayValidator = new VehicleIdParkingDayValidator();
            motorcycleParkingSpaceValidator = new MotorcycleParkingSpaceValidator(MotorCycleDao);
            uniqueVehicleIdValidator = new UniqueVehicleIdValidator(MotorCycleDao);
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
                MotorCycleDao.CreateMotorcycle(vehicle);
            }
        }

        private void CheckPermissionsToPark(Motorcycle vehicle)
        {
            IsVehicleValidId = false;
            ParkingSpaceInParkingLot = false;
            AllowedbyId = false;
            if (vehicleIdParkingDayValidator.IsAllowedToPark(vehicle.VehicleId, vehicle.DateOfEntry))
            {
                AllowedbyId = true;
            }
            if (motorcycleParkingSpaceValidator.IsVehicleSpaceInParkingLot())
            {
                ParkingSpaceInParkingLot = true;
            }
            if (uniqueVehicleIdValidator.IsAValidId(vehicle.VehicleId))
            {
                IsVehicleValidId = true;
            }
        }
    }
}
