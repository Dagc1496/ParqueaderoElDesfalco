using System.Collections.Generic;
using System.Threading.Tasks;
using ParqueaderoElDesfalco.Core.Domain;

namespace ParqueaderoElDesfalco.Core.Persistence.Daos
{
    public interface ICarDao
    {
        Task CreateCar(Car car);
        Task RemoveCar(Car car);
        Task<List<Car>> GetAllCars();
    }
}
