using System;
using Realms;

namespace ParqueaderoElDesfalco.Core.Persistence.Entities
{
    public class CarEntity : RealmObject
    {

        #region Properties

        [PrimaryKey]
        public string CarId { get; set; }

        public DateTimeOffset DateOfEntry { get; set; }

        #endregion

        #region Constructor

        public CarEntity() { }

        #endregion
    }
}