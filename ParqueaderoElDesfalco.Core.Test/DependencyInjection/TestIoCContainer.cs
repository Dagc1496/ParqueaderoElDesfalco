using System;
using Autofac;
using ParqueaderoElDesfalco.Core.DependencyInjection;
using ParqueaderoElDesfalco.Core.Persistence.Daos;
using ParqueaderoElDesfalco.Core.Persistence.Daos.Implementations.Mock;

namespace ParqueaderoElDesfalco.Core.Test.DependencyInjection
{
    public class TestIoCContainer : IoCContainer
    {
        protected override void RegisterDependencies(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<CarDaoMock>().As<ICarDao>();
            containerBuilder.RegisterType<MotorcycleDaoMock>().As<IMotorcycleDao>();
        }
    }
}
