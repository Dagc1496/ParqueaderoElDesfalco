using Android.OS;
using Android.Support.V7.App;
using Autofac;
using ParqueaderoElDesfalco.Droid.DependencyInjection;

namespace ParqueaderoElDesfalco.Droid.Activities
{
    public class BaseActivity: AppCompatActivity
    {

        #region Class methods

        public ILifetimeScope ConfigureDependencies()
        {
            var concreteIoCContainer = new PlatformIoCContainer();
            IContainer container = concreteIoCContainer.CreateContainer();
            return container.BeginLifetimeScope();
        }

        #endregion

        #region Protected methods

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            ConfigureDependencies();
        }

        #endregion
    }
}
