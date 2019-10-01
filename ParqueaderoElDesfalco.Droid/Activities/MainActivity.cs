using Android.App;
using Android.OS;
using Autofac;
using ParqueaderoElDesfalco.Core.ServiceDomain;

namespace ParqueaderoElDesfalco.Droid.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : BaseActivity
    {

        private CarServiceDomain carServiceDomain;
        private MotorcycleServiceDomain motorcycleServiceDomain;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            SetDependencies();
        }

        private void SetDependencies()
        {
            carServiceDomain = ConfigureDependencies().Resolve<CarServiceDomain>();
            motorcycleServiceDomain = ConfigureDependencies().Resolve<MotorcycleServiceDomain>();
        }
    }
}

