using Autofac;
using ParqueaderoElDesfalco.Core.ServiceDomain;

namespace ParqueaderoElDesfalco.Core.DependencyInjection
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(CarServiceDomain)).PropertiesAutowired();
            builder.RegisterType(typeof(MotorcycleServiceDomain)).PropertiesAutowired();
        }
    }
}
