using System;
using Autofac;
using ParqueaderoElDesfalco.Core.Domain.DomainValidators;

namespace ParqueaderoElDesfalco.Core.DependencyInjection
{
    public class ValidatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(UniqueVehicleIdValidator)).PropertiesAutowired();
            builder.RegisterType(typeof(CarParkingSpaceValidator)).PropertiesAutowired();
            builder.RegisterType(typeof(MotorcycleParkingSpaceValidator)).PropertiesAutowired();
        }
    }
}
