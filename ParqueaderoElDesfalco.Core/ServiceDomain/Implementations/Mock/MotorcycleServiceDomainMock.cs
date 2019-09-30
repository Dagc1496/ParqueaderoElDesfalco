using System;
using System.Collections.Generic;
using ParqueaderoElDesfalco.Core.Domain;

namespace ParqueaderoElDesfalco.Core.ServiceDomain.Implementations.Mock
{
    public class MotorcycleServiceDomainMock : IVehicleServiceDomain<Motorcycle>
    {
        private readonly DateTimeOffset defaultDate = DateTimeOffset.Now;

        private string defaultMotorcycleId = "onemotorcycleid";
        private const int numberOfMotorcycles = 3;
        private const int defaultCilindraje = 200;

        private Motorcycle defaultMotorcycle;
        private List<Motorcycle> motorcycles;

        public MotorcycleServiceDomainMock()
        {
            PopulateMotorcycleList();
        }

        public List<Motorcycle> GetAllVehicles()
        {
            return motorcycles;
        }

        public void RemoveVechielFromDB(Motorcycle vehicle){}

        public void SaveVechicleOnDb(Motorcycle vehicle){}

        private void PopulateMotorcycleList()
        {
            motorcycles = new List<Motorcycle>();
            for (int i = 0; i < numberOfMotorcycles; i++)
            {
                defaultMotorcycleId += i.ToString();
                defaultMotorcycle = new Motorcycle(defaultMotorcycleId, defaultDate, defaultCilindraje);
                motorcycles.Add(defaultMotorcycle);
            }
        }

        public void CheckPermissionsToPark(Motorcycle vehicle)
        {}
    }
}
