using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Persistence.Daos;

namespace ParqueaderoElDesfalco.Core.Validators
{
    public class MotorcycleParkingSpaceValidator : IVehicleParkingSpaceValidator
    {

        private IMotorcycleDao MotorcycleDaoObject;
        private readonly int LimitOfMotorcycle = 10;

        public MotorcycleParkingSpaceValidator(IMotorcycleDao motorcycleDao)
        {
            MotorcycleDaoObject = motorcycleDao;
        }

        public bool IsVehicleSpaceInParkingLot()
        {
            List<Motorcycle> motorcycles = MotorcycleDaoObject.GetAllMotorcycles();
            if (motorcycles.Count == LimitOfMotorcycle)
            {
                return false;
            }
            return true;
        }
    }
}
