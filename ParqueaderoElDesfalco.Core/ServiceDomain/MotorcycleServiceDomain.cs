﻿using System;
using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Domain.DomainExeptions;
using ParqueaderoElDesfalco.Core.Persistence.Daos;

namespace ParqueaderoElDesfalco.Core.ServiceDomain
{ 
    public class MotorcycleServiceDomain : VehicleServiceDomain
    {

        private readonly IMotorcycleDao MotorCycleDao;

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
            SetUpValidators(vehicle,MotorCycleDao);
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
    }
}
