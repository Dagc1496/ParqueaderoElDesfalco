using System;
using Autofac;
using ParqueaderoElDesfalco.Core.Persistence;
using ParqueaderoElDesfalco.Core.Persistence.Daos;
using ParqueaderoElDesfalco.Core.Persistence.Daos.Implementations.Mock;
using ParqueaderoElDesfalco.Core.Persistence.Daos.Implementations.Real;

namespace ParqueaderoElDesfalco.Core.DependencyInjection
{
    public class DaoModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
#if MOCK
            builder.RegisterType<CarDaoMock>().As<ICarDao>();
            builder.RegisterType<MotorcycleDaoMock>().As<IMotorcycleDao>();
#else
            builder.RegisterType<CarDao>().As<ICarDao>();
            builder.RegisterType<MotorcycleDao>().As<IMotorcycleDao>();
            builder.RegisterType<DatabaseManager>().As<IDatabaseManager>();
#endif
        }
    }
}
