using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Widget;
using Autofac;
using Newtonsoft.Json;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.ServiceDomain;
using ParqueaderoElDesfalco.Droid.Adapters;
using ParqueaderoElDesfalco.Droid.Services;

namespace ParqueaderoElDesfalco.Droid.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : BaseActivity
    {
        private RecyclerView carRecyclerView;
        private RecyclerView motorcyclesRecyclerView;
        private CarServiceDomain carServiceDomain;
        private IDialogsService dialogsService;
        private Button NewCarButton;
        private Button NewMotorcycleButton;
        private MotorcycleServiceDomain motorcycleServiceDomain;
        private List<Car> carList;
        private List<Motorcycle> motorcycleList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            SetDependencies();
            ConfigViews();
        }

        private void ConfigViews()
        {
            NewCarButton = FindViewById<Button>(Resource.Id.btn_park_new_car);
            NewCarButton.Click += btnNewCar_Click;
            NewMotorcycleButton = FindViewById<Button>(Resource.Id.btn_park_new_motorcycle);
            NewMotorcycleButton.Click += btnNewMotorcycle_Click;
            ConfigGeneralRecyclerView();
            dialogsService.UserDialogsInit(this);
        }

        private void ConfigGeneralRecyclerView()
        {
            motorcyclesRecyclerView = FindViewById<RecyclerView>(Resource.Id.motorcycles_recyclerview);
            motorcyclesRecyclerView.NestedScrollingEnabled = false;
            carRecyclerView = FindViewById<RecyclerView>(Resource.Id.cars_recyclerview);
            carRecyclerView.NestedScrollingEnabled = false;
        }

        protected override void OnStart()
        {
            base.OnStart();
            GetVehiclesList();
            ConfigCarRecyclerView(carList);
            ConfigMotorcycleRecyclerView(motorcycleList);
        }

        private void btnNewCar_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(CarSaveActivity));
            StartActivity(intent);
        }

        private void btnNewMotorcycle_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MotorcycleSaveActivity));
            StartActivity(intent);
        }

        private void GetVehiclesList()
        {
            carList = carServiceDomain.GetAllVehicles();
            motorcycleList = motorcycleServiceDomain.GetAllVehicles();
        }

        private void SetDependencies()
        {
            carServiceDomain = ConfigureDependencies().Resolve<CarServiceDomain>();
            motorcycleServiceDomain = ConfigureDependencies().Resolve<MotorcycleServiceDomain>();
            dialogsService = ConfigureDependencies().Resolve<IDialogsService>();
        }

        private void ConfigCarRecyclerView(List<Car> cars)
        {
            var adapter = new CarAdapter(cars);
            adapter.OnItemClick += CarAdapterOnItemClick;
            carRecyclerView.SetLayoutManager(new LinearLayoutManager(this));
            carRecyclerView.SetAdapter(adapter);
        }

        private void CarAdapterOnItemClick(object sender,Car car)
        {
            GoToVehicleExitActivity(car);
        }

        private void ConfigMotorcycleRecyclerView(List<Motorcycle> motorcycles)
        {
            var adapter = new MotorcycleAdapter(motorcycles);
            adapter.OnItemClick += MotorcycleAdapterOnItemClick;
            motorcyclesRecyclerView.SetLayoutManager(new LinearLayoutManager(this));
            motorcyclesRecyclerView.SetAdapter(adapter);
        }

        private void MotorcycleAdapterOnItemClick(object sender, Motorcycle motorcycle)
        {
            GoToVehicleExitActivity(motorcycle);
        }

        private void GoToVehicleExitActivity<T>(T vehicle)
        {
            var intent = new Intent(this, typeof(VehicleExitActivity));
            var extras = new Bundle();
            if(vehicle.GetType() == typeof(Car))
            {
                extras.PutString("car", JsonConvert.SerializeObject(vehicle));
            }else
            if(vehicle.GetType() == typeof(Motorcycle))
            {
                extras.PutString("motorcycle", JsonConvert.SerializeObject(vehicle));
            }
            intent.PutExtras(extras);

            StartActivity(intent);
        }
    }
}

