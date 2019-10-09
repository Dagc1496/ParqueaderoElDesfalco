using System;
using Realms;

namespace ParqueaderoElDesfalco.Core.Persistence.Entities
{
    public class MotorcycleEntity : RealmObject
    {

        #region Properties

        [PrimaryKey]
        public string MotorcycleId { get; set; }
        public DateTimeOffset DateOfEntry { get; set; }
        public int Cilindraje { get; set; }

        #endregion

        #region Constructor

        public MotorcycleEntity() { }

        #endregion
    }
}
