using Android.OS;
using Android.Support.V7.App;
using Autofac;
using ParqueaderoElDesfalco.Core.DependencyInjection;

namespace ParqueaderoElDesfalco.Droid.Activities
{
    public class BaseActivity: AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            ConfigureDependencies();
        }

        public ILifetimeScope ConfigureDependencies()
        {
            var concreteIoCContainer = new IoCContainer();
            IContainer container = concreteIoCContainer.CreateContainer();
            return container.BeginLifetimeScope();
        }


    }
}
