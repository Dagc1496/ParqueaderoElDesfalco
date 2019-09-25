using System.Collections.Generic;
using System.Threading.Tasks;
using ParqueaderoElDesfalco.Core.Domain;

namespace ParqueaderoElDesfalco.Core.Persistence.Daos
{
    public interface IMotorcycleDao
    {
        Task CreateMotorcycle(Motorcycle motorcycle);
        Task RemoveMotorcycle(Motorcycle motorcycleId);
        Task<List<Motorcycle>> GetAllMotorcycles();
    }
}