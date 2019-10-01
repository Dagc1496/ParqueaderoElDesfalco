
using Autofac;

namespace ParqueaderoElDesfalco.Core.DependencyInjection
{
    public class IoCContainer
    {
        public IContainer CreateContainer()
        {
            var containerBuilder = new ContainerBuilder();
            RegisterSharedDependencies(containerBuilder);
            return containerBuilder.Build();
        }

        private void RegisterSharedDependencies(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<DomainModule>();
            containerBuilder.RegisterModule<DaoModule>();
        }
    }
}
