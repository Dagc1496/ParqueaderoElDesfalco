using System;
using System.Collections.Generic;

namespace ParqueaderoElDesfalco.Core.ServiceDomain
{
    public interface IVehicleServiceDomain<T>
    {
        void SaveVechicleOnDb(T vehicle);
        List<T> GetAllVehicles();
        void RemoveVechielFromDB(T vehicle);
        void CheckPermissionsToPark(T vehicle);
    }
}
