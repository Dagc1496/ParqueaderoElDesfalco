using System;
using Realms;

namespace ParqueaderoElDesfalco.Core.models
{
    public class MotorcycleEntity : RealmObject
    {
        [PrimaryKey]
        public string MotorcycleId { get; set; }
        public int Cilindraje { get; set; }
        public DateTimeOffset DateOfEntry { get; set; }
        public DateTimeOffset? DepartureDate { get; set; }
    }
}
