using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain.DomainObjects;

namespace ParqueaderoElDesfalco.Core.Persistence.Daos
{
    public interface IMotorcycleDao
    {
        void CreateMotorcycle(Motorcycle motorcycle);
        void RemoveMotorcycle(Motorcycle motorcycle);
        List<Motorcycle> GetAllVehicles();
    }
}
