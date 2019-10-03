using System;
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
            if(motorcycle != null)
            {
                motorcycle.CalculateParkingPrice(vehicleDepartureTime);
            }
        }

        public void RemoveVechielFromDB(Motorcycle vehicle)
        {
            if(vehicle!= null)
            {
                MotorCycleDao.RemoveMotorcycle(vehicle);
            }
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
                throw (new VehicleIdException("ByDay"));
            }
            if (!IsVehicleValidId)
            {
                throw (new VehicleIdException("ById"));
            }
            if (HaveEmojis)
            {
                throw (new VehicleIdException("ById"));
            }
            else
            {
                MotorCycleDao.CreateMotorcycle(vehicle);
            }
        }
    }
}
