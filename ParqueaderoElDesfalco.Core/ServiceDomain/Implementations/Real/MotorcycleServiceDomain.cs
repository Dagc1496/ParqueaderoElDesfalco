using System;
using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Domain.DomainExeptions;
using ParqueaderoElDesfalco.Core.Domain.DomainValidators;
using ParqueaderoElDesfalco.Core.Persistence.Daos;
using ParqueaderoElDesfalco.Core.Validators;

namespace ParqueaderoElDesfalco.Core.ServiceDomain.Implementations.Real
{
    public class MotorcycleServiceDomain : IVehicleServiceDomain<Motorcycle>
    {

        private readonly IMotorcycleDao MotorCycleDao;
        private VehicleIdParkingDayValidator vehicleIdParkingDayValidator;
        private MotorcycleParkingSpaceValidator motorcycleParkingSpaceValidator;
        private bool ParkingSpaceInParkingLot;
        private bool AllowedbyId;

        public MotorcycleServiceDomain(IMotorcycleDao motorCycleDao)
        {
            MotorCycleDao = motorCycleDao;
        }

        public List<Motorcycle> GetAllVehicles()
        {
            List<Motorcycle> motorcycles = MotorCycleDao.GetAllMotorcycles();
            return motorcycles;
        }

        public void RemoveVechielFromDB(Motorcycle vehicle)
        {
            MotorCycleDao.RemoveMotorcycle(vehicle);
        }

        public void SaveVechicleOnDb(Motorcycle vehicle)
        {
            vehicleIdParkingDayValidator = new VehicleIdParkingDayValidator();
            motorcycleParkingSpaceValidator = new MotorcycleParkingSpaceValidator(MotorCycleDao);
            CheckPermissionsToPark(vehicle);
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
                MotorCycleDao.CreateMotorcycle(vehicle);
            }
        }

        public void CheckPermissionsToPark(Motorcycle vehicle)
        {
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
        }
    }
}
