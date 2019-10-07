using System;
using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Domain.DomainExeptions;
using ParqueaderoElDesfalco.Core.Domain.DomainValidators;
using ParqueaderoElDesfalco.Core.Persistence.Daos;

namespace ParqueaderoElDesfalco.Core.ServiceDomain
{
    public class CarServiceDomain : VehicleServiceDomain
    {

        private readonly ICarDao carDao;

        private CarParkingSpaceValidator carParkingSpaceValidator;

        private UniqueVehicleIdValidator uniqueVehicleIdValidator;

        public CarServiceDomain(ICarDao carDao)
        {
            this.carDao = carDao;
        }

        public void CalculatePriceOfPark(Car car, DateTimeOffset vechicleDepartureTiem)
        {
            if(car != null)
            {
                car.CalculateParkingPrice(vechicleDepartureTiem);
            }
        }

        public List<Car> GetAllVehicles()
        {
            List<Car> cars = carDao.GetAllCars();
            return cars;
        }

        public void RemoveVechielFromDB(Car vehicle)
        {
            if(vehicle != null)
            {
                carDao.RemoveCar(vehicle);
            }
        }

        public void SaveVechicleOnDb(Car vehicle)
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

            if (HaveEmojis)
            {
                throw (new VehicleIdException("ById"));
            }
            else
            {
                carDao.CreateCar(vehicle);
            }
        }

        protected override void CheckPermissionsToPark(Vehicle vehicle)
        {
            base.CheckPermissionsToPark(vehicle);
            if (carParkingSpaceValidator.IsVehicleSpaceInParkingLot())
            {
                ParkingSpaceInParkingLot = true;
            }
            if (uniqueVehicleIdValidator.IsAValidId(vehicle.VehicleId))
            {
                IsVehicleValidId = true;
            }
        }

        protected override void SetUpValidators(Vehicle vehicle)
        {
            base.SetUpValidators(vehicle);
            if (vehicle != null)
            {
                carParkingSpaceValidator = new CarParkingSpaceValidator(carDao);
                uniqueVehicleIdValidator = new UniqueVehicleIdValidator(carDao);
                CheckPermissionsToPark(vehicle);
            }
        }
    }
}
