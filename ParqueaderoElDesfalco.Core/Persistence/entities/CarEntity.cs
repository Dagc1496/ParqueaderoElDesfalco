using System;
using Realms;

namespace ParqueaderoElDesfalco.Core.Persistence.Entities
{
    public class CarEntity : RealmObject
    {
        public CarEntity() { }

        [PrimaryKey]
        public string CarId { get; set; }
        public DateTimeOffset DateOfEntry { get; set; }
    }
}