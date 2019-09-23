using System;
using Realms;

namespace ParqueaderoElDesfalco.Core.models.entities
{
    public class CarEntity : RealmObject
    {
        public CarEntity() { }
        public CarEntity(Car car) { }

        [PrimaryKey]
        public string CarId { get; set; }
        public DateTimeOffset DateOfEntry { get; set; }
    }
}
