using System;
using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain;

namespace ParqueaderoElDesfalco.Core.Persistence.Daos.Implementations.Mock
{
    public class MotorcycleDaoMock : IMotorcycleDao
    {

        private readonly List<Motorcycle> motorcycles;
        private readonly string defaultId = "defaultId";
        private readonly DateTimeOffset defaultDate = DateTimeOffset.Now;
        private const int defaultCilindraje = 200;
        private readonly List<string> vehicleIds;

        public MotorcycleDaoMock()
        {
            motorcycles = new List<Motorcycle>();
            vehicleIds = new List<string>();
            Motorcycle motorcycle = new Motorcycle(defaultId, defaultDate, defaultCilindraje);
            motorcycles.Add(motorcycle);
        }

        public void CreateMotorcycle(Motorcycle motorcycle)
        {
            if(motorcycle != null)
            {
                vehicleIds.Add(motorcycle.VehicleId);
                motorcycles.Add(motorcycle);
            }
        }

        public void RemoveMotorcycle(Motorcycle motorcycle)
        {
            if(motorcycle != null)
            {
                vehicleIds.Remove(motorcycle.VehicleId);
                motorcycles.Remove(motorcycle);
            }
        }

        public List<Motorcycle> GetAllMotorcycles()
        {
            return motorcycles;
        }

        public List<string> GetAllVehicleIds()
        {
            return vehicleIds;
        }
    }
}
