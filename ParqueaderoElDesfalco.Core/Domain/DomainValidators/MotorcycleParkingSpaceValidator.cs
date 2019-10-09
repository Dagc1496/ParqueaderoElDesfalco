using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain.Models;
using ParqueaderoElDesfalco.Core.Persistence.Daos;

namespace ParqueaderoElDesfalco.Core.Domain.DomainValidators
{
    public class MotorcycleParkingSpaceValidator
    {

        #region Class vars and constants

        private readonly IMotorcycleDao motorcycleDao;
        private readonly int limitOfMotorcycle = 10;

        #endregion

        #region Constructor

        public MotorcycleParkingSpaceValidator(IMotorcycleDao motorcycleDao)
        {
            this.motorcycleDao = motorcycleDao;
        }

        #endregion

        #region Class methods

        public bool IsVehicleSpaceInParkingLot()
        {
            List<Motorcycle> motorcycles = motorcycleDao.GetAllVehicles();
            if (motorcycles.Count == limitOfMotorcycle)
            {
                return false;
            }
            return true;
        }

        #endregion
    }
}
