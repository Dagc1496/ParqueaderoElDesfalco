using System.Collections.Generic;
using System.Threading.Tasks;
using ParqueaderoElDesfalco.Core.Domain;

namespace ParqueaderoElDesfalco.Core.Persistence.Daos
{
    public interface IMotorcycleDao
    {
        void CreateMotorcycle(Motorcycle motorcycle);
        void RemoveMotorcycle(Motorcycle motorcycleId);
        List<Motorcycle> GetAllMotorcycles();
    }
}