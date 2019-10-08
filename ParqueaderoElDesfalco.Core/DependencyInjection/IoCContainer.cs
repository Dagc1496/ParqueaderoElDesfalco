
using Autofac;

namespace ParqueaderoElDesfalco.Core.DependencyInjection
{
    public abstract class IoCContainer
    {
        public IContainer CreateContainer()
        {
            var containerBuilder = new ContainerBuilder();
            RegisterSharedDependencies(containerBuilder);
            RegisterDependencies(containerBuilder);
            return containerBuilder.Build();
        }

        private void RegisterSharedDependencies(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<DomainModule>();
            containerBuilder.RegisterModule<DaoModule>();
            containerBuilder.RegisterModule<ValidatorModule>();
        }

        protected abstract void RegisterDependencies(ContainerBuilder containerBuilder);
    }
}
