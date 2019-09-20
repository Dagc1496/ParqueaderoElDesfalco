using System;
using Realms;

namespace ParqueaderoElDesfalco.Core.models
{
    public class MotorcycleModel : RealmObject
    {
        [PrimaryKey]
        public string MotorcycleId { get; set; }
        public int Cilindraje { get; set; }
        public DateTimeOffset TimeOfEntry { get; set; }
        public DateTimeOffset? DepartureTime { get; set; }
    }
}
