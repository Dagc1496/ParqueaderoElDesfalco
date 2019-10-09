using System;
using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain.DomainExeptions;
using ParqueaderoElDesfalco.Core.Domain.Models;
using ParqueaderoElDesfalco.Core.Domain.DomainValidators;
using ParqueaderoElDesfalco.Core.Persistence.Daos;

namespace ParqueaderoElDesfalco.Core.ServiceDomain
{ 
    public class MotorcycleServiceDomain : VehicleServiceDomain
    {

        #region Class vars and constants

        private readonly IMotorcycleDao motorcycleDao;
        private MotorcycleParkingSpaceValidator motorcycleParkingSpaceValidator;
        private MotorcycleUniqueIdValidator motorcycleUniqueIdValidator;

        #endregion

        #region Constructor

        public MotorcycleServiceDomain(IMotorcycleDao motorcycleDao)
        {
            this.motorcycleDao = motorcycleDao;
        }

        #endregion

        #region Class methods

        public List<Motorcycle> GetAllVehicles()
        {
            List<Motorcycle> motorcycles = motorcycleDao.GetAllVehicles();
            return motorcycles;
        }

        public void CalculatePriceOfPark(Motorcycle motorcycle, DateTimeOffset vehicleDepartureTime)
        {
            if (motorcycle != null)
            {
                motorcycle.CalculateParkingPrice(vehicleDepartureTime);
            }
        }

        public void RemoveVechielFromDB(Motorcycle vehicle)
        {
            if (vehicle != null)
            {
                motorcycleDao.RemoveMotorcycle(vehicle);
            }
        }

        public void SaveVechicleOnDb(Motorcycle vehicle)
        {
            SetUpValidators(vehicle);
            if (!ParkingSpaceInParkingLot)
            {
                throw (new ParkingLotException("No Space"));
            }
            if (!AllowedbyId)
            {
                throw (new VehicleIdException("ByDay"));
            }
            if (!IsVehicleValidId)
            {
                throw (new VehicleIdException("ById"));
            }
            else
            {
                motorcycleDao.CreateMotorcycle(vehicle);
            }
        }

        #endregion

        #region Protected methods

        protected override void CheckPermissionsToPark(Vehicle vehicle)
        {
            base.CheckPermissionsToPark(vehicle);
            if (motorcycleParkingSpaceValidator.IsVehicleSpaceInParkingLot())
            {
                ParkingSpaceInParkingLot = true;
            }
            if (motorcycleUniqueIdValidator.IsAValidId(vehicle.VehicleId))
            {
                IsVehicleValidId = true;
            }
        }

        protected override void SetUpValidators(Vehicle vehicle)
        {
            base.SetUpValidators(vehicle);
            if (vehicle != null)
            {
                motorcycleParkingSpaceValidator = new MotorcycleParkingSpaceValidator(motorcycleDao);
                motorcycleUniqueIdValidator = new MotorcycleUniqueIdValidator(motorcycleDao);
                CheckPermissionsToPark(vehicle);
            }
        }

        #endregion
    }
}