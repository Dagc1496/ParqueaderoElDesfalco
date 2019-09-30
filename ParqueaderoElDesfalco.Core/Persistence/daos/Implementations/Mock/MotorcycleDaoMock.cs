using System;
using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain;

namespace ParqueaderoElDesfalco.Core.Persistence.Daos.Implementations.Mock
{
    public class MotorcycleDaoMock : IMotorcycleDao
    {

        private List<Motorcycle> motorcycles;
        private readonly string defaultId = "defaultId";
        private readonly DateTimeOffset defaultDate = DateTimeOffset.Now;
        private const int defaultCilindraje = 200;

        public MotorcycleDaoMock()
        {
            motorcycles = new List<Motorcycle>();
            Motorcycle motorcycle = new Motorcycle(defaultId, defaultDate, defaultCilindraje);
            motorcycles.Add(motorcycle);
        }

        public void CreateMotorcycle(Motorcycle motorcycle)
        {
            motorcycles.Add(motorcycle);
        }

        public void RemoveMotorcycle(Motorcycle motorcycle)
        {
            motorcycles.Remove(motorcycle);
        }

        public List<Motorcycle> GetAllMotorcycles()
        {
            return motorcycles;
        }
    }
}
