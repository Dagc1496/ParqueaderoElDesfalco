using System;
using Autofac;
using ParqueaderoElDesfalco.Core.DependencyInjection;
using ParqueaderoElDesfalco.Droid.Helpers.UserDialogsHelper;

namespace ParqueaderoElDesfalco.Droid.DependencyInjection
{
    public class PlatformIoCContainer : IoCContainer
    {
        protected override void RegisterDependencies(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<UserDialogsHelper>().As<IUserDialogsHelper>();
        }
    }
}
