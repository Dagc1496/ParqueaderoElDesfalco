using System;
using Realms;

namespace ParqueaderoElDesfalco.Core.models
{
    public class CarEntity : RealmObject
    {
        [PrimaryKey]
        public string CarId { get; set; }
        public DateTimeOffset DateOfEntry { get; set; }
        public DateTimeOffset? DepartureDate { get; set; }
    }
}
