using System;
using Autofac;
using ParqueaderoElDesfalco.Core.Test.DependencyInjection;

namespace ParqueaderoElDesfalco.Core.Test.ServiceDomainTest
{
    public abstract class BaseServiceDomain
    {
        public ILifetimeScope ConfigureDependencies()
        {
            var concreteIoCContainer = new TestIoCContainer();
            IContainer container = concreteIoCContainer.CreateContainer();
            return container.BeginLifetimeScope();
        }
    }
}
