using System;
using Realms;

namespace ParqueaderoElDesfalco.Core.Persistence.Entities
{
    public class MotorcycleEntity : RealmObject
    {
        public MotorcycleEntity() { }

        [PrimaryKey]
        public string MotorcycleId { get; set; }
        public int Cilindraje { get; set; }
        public DateTimeOffset DateOfEntry { get; set; }
    }
}
