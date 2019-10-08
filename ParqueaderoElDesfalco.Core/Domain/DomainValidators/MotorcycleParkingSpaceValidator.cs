using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain.DomainObjects;
using ParqueaderoElDesfalco.Core.Persistence.Daos;

namespace ParqueaderoElDesfalco.Core.Domain.DomainValidators
{
    public class MotorcycleParkingSpaceValidator
    {

        private readonly IMotorcycleDao motorcycleDao;
        private readonly int limitOfMotorcycle = 10;

        public MotorcycleParkingSpaceValidator(IMotorcycleDao motorcycleDao)
        {
            this.motorcycleDao = motorcycleDao;
        }

        public bool IsVehicleSpaceInParkingLot()
        {
            List<Motorcycle> motorcycles = motorcycleDao.GetAllVehicles();
            if (motorcycles.Count == limitOfMotorcycle)
            {
                return false;
            }
            return true;
        }
    }
}
