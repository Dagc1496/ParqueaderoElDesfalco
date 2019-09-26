using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Persistence.Entities;

namespace ParqueaderoElDesfalco.Core.Persistence
{
    public interface IDatabaseManager
    {
        void InitilizeDB();

        void SaveOnDB(MotorcycleEntity motorcycleEntity);

        void SaveOnDB(CarEntity carEntity);

        void RemoveFromDB(MotorcycleEntity motorcycleEntity);

        void RemoveFromDB(CarEntity carEntity);

        List<CarEntity> GetAllCars();

        List<MotorcycleEntity> GetAllMotorcycles();
    }
}
