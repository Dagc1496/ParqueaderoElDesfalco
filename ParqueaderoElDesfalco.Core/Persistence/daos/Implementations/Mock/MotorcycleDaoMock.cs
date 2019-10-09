using System;
using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain.Models;

namespace ParqueaderoElDesfalco.Core.Persistence.Daos.Implementations.Mock
{
    public class MotorcycleDaoMock : IMotorcycleDao
    {

        #region Class vars and constants

        private List<Motorcycle> motorcycles;
        private readonly string defaultId = "def-00d";
        private readonly DateTimeOffset defaultDate = DateTimeOffset.Now;
        private const int defaultCilindraje = 200;
        private List<string> vehicleIds;

        #endregion

        #region Constructor

        public MotorcycleDaoMock()
        {
            motorcycles = new List<Motorcycle>();
            vehicleIds = new List<string>();
            Motorcycle motorcycle = new Motorcycle(defaultId, defaultDate, defaultCilindraje);
            motorcycles.Add(motorcycle);
        }

        #endregion

        #region Class methods

        public void CreateMotorcycle(Motorcycle motorcycle)
        {
            if (motorcycle != null)
            {
                vehicleIds.Add(motorcycle.VehicleId);
                motorcycles.Add(motorcycle);
            }
        }

        public void RemoveMotorcycle(Motorcycle motorcycle)
        {
            if (motorcycle != null)
            {
                vehicleIds.Remove(motorcycle.VehicleId);
                motorcycles.Remove(motorcycle);
            }
        }

        public List<Motorcycle> GetAllVehicles()
        {
            return motorcycles;
        }

        public List<string> GetAllVehicleIds()
        {
            return vehicleIds;
        }

        #endregion
    }
}
