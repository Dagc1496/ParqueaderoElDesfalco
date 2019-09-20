using System;
using Realms;

namespace ParqueaderoElDesfalco.Core.models
{
    public class CarModel : RealmObject
    {
        [PrimaryKey]
        public string CarId { get; set; }
        public DateTimeOffset TimeOfEntry { get; set; }
        public DateTimeOffset? DepartureTime { get; set; }
    }
}
