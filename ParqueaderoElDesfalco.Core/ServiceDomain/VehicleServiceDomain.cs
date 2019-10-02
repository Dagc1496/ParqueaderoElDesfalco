using System;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Domain.DomainValidators;
using ParqueaderoElDesfalco.Core.Persistence.Daos;
using ParqueaderoElDesfalco.Core.Validators;

namespace ParqueaderoElDesfalco.Core.ServiceDomain
{
    public abstract class VehicleServiceDomain
    {

        private VehicleIdParkingDayValidator vehicleIdParkingDayValidator;
        private UniqueVehicleIdValidator uniqueVehicleIdValidator;
        private CarParkingSpaceValidator carParkingSpaceValidator;
        private MotorcycleParkingSpaceValidator motorcycleParkingSpaceValidator;
        private ICarDao CarDao;
        private IMotorcycleDao MotorcycleDao;
        protected bool ParkingSpaceInParkingLot;
        protected bool AllowedbyId;
        protected bool IsVehicleValidId;

        private void CheckPermissionsToPark(Vehicle vehicle)
        {
            IsVehicleValidId = false;
            ParkingSpaceInParkingLot = false;
            AllowedbyId = false;
            if (vehicleIdParkingDayValidator.IsAllowedToPark(vehicle.VehicleId, vehicle.DateOfEntry))
            {
                AllowedbyId = true;
            }
            if (uniqueVehicleIdValidator.IsAValidId(vehicle.VehicleId))
            {
                IsVehicleValidId = true;
            }
            if (vehicle.GetType() == typeof(Car))
            {
                if (carParkingSpaceValidator.IsVehicleSpaceInParkingLot())
                {
                    ParkingSpaceInParkingLot = true;
                }
            }
            if (vehicle.GetType() == typeof(Motorcycle))
            {
                if (motorcycleParkingSpaceValidator.IsVehicleSpaceInParkingLot())
                {
                    ParkingSpaceInParkingLot = true;
                }
            }
        }

        protected void SetUpValidators<T>(Vehicle vehicle, T VehicleDao)
        {
            vehicleIdParkingDayValidator = new VehicleIdParkingDayValidator();
            if(vehicle.GetType() == typeof(Car))
            {
                CarDao = (ICarDao)VehicleDao;
                carParkingSpaceValidator = new CarParkingSpaceValidator(CarDao);
                uniqueVehicleIdValidator = new UniqueVehicleIdValidator(CarDao);
                CheckPermissionsToPark(vehicle);
            }
            if(vehicle.GetType() == typeof(Motorcycle))
            {
                MotorcycleDao = (IMotorcycleDao)VehicleDao;
                motorcycleParkingSpaceValidator = new MotorcycleParkingSpaceValidator(MotorcycleDao);
                uniqueVehicleIdValidator = new UniqueVehicleIdValidator(MotorcycleDao);
                CheckPermissionsToPark(vehicle);
            }
        }
    }
}