using System.Collections.Generic;
using System.Threading.Tasks;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Mappers;
using ParqueaderoElDesfalco.Core.Persistence.Entities;

namespace ParqueaderoElDesfalco.Core.Persistence.Daos
{
    public class CarDao : ICarDao
    {
        private CarMapper CarMapperObject;

        private readonly DatabaseManager DatabaseManagerObject;

        public CarDao()
        {
            DatabaseManagerObject = new DatabaseManager();
            DatabaseManagerObject.InitilizeDB();
            CarMapperObject = new CarMapper();
        }

        public async Task CreateCar(Car car)
        {
            CarEntity carEntity = CarMapperObject.MapCarToEntity(car);
            await DatabaseManagerObject.SaveOnDB(carEntity);
        }

        public async Task<List<Car>> GetAllCars()
        {
            List<CarEntity> carEntities = await DatabaseManagerObject.GetAllCars();
            List<Car> cars = new List<Car>();
            if (carEntities == null || carEntities.Count == 0)
            {
                return cars;
            }
            foreach (CarEntity carEntity in carEntities)
            {
                Car car = CarMapperObject.MapEntityToCar(carEntity);
                cars.Add(car);
            }
            return cars;
        }

        public async Task RemoveCar(Car car)
        {
            CarEntity carEntity = CarMapperObject.MapCarToEntity(car);
            await DatabaseManagerObject.RemoveFromDB(carEntity);
        }
    }
}
