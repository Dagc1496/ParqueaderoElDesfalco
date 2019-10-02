using System;
using Autofac;
using ParqueaderoElDesfalco.Core.DependencyInjection;
using ParqueaderoElDesfalco.Droid.Services;

namespace ParqueaderoElDesfalco.Droid.DependencyInjection
{
    public class PlatformIoCContainer : IoCContainer
    {

        protected override void RegisterDependencies(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<DialogsService>().As<IDialogsService>();
        }
    }
}
