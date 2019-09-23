using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ParqueaderoElDesfalco.Core.Persistence.Entities;
using Realms;

namespace ParqueaderoElDesfalco.Core.Persistence
{
    public interface IDatabaseManager
    {
        Realm InitilizeDB();

        Task SaveOnDB(CarEntity carEntity);

        Task SaveOnDB(MotorcycleEntity motorcycleEntity);

        Task RemoveFromDB(CarEntity carEntity);

        Task RemoveFromDB(MotorcycleEntity motorcycleEntity);

        List<CarEntity> GetAllCars();

        List<MotorcycleEntity> GetAllMotorcycles();
    }
}
