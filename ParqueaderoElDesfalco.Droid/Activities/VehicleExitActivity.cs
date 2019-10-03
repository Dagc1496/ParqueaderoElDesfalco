using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Autofac;
using Newtonsoft.Json;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.ServiceDomain;
using ParqueaderoElDesfalco.Droid.Services;

namespace ParqueaderoElDesfalco.Droid.Activities
{
    [Activity(Label = "@string/pay_activity", Theme = "@style/AppTheme")]
    public class VehicleExitActivity : BaseActivity
    {
        private TextView LeavingVehicleId;
        private TextView LeavingVehicleDateOfEntry;
        private TextView LeavingVehicleDateOfDeparture;
        private TextView LeavingVehiclePriceOfParking;
        private readonly DateTimeOffset dateOfDepartureActual = DateTimeOffset.Now;
        private DateTimeOffset dateOfDeparture;
        private Button PayAndOutButton;
        private CarServiceDomain carServiceDomain;
        private MotorcycleServiceDomain motorcycleServiceDomain;
        private Car leavingCar;
        private Motorcycle leavingMotorcycle;
        private IDialogsService dialogsService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_exit_vehicle);

            ConfigViews();
            GetExtras();            
        }

        private void ConfigViews()
        {
            LeavingVehicleId = FindViewById<TextView>(Resource.Id.vehicle_id);
            LeavingVehicleDateOfEntry = FindViewById<TextView>(Resource.Id.vehicle_date_of_entry);
            LeavingVehicleDateOfDeparture = FindViewById<TextView>(Resource.Id.vehicle_date_of_departure);
            LeavingVehiclePriceOfParking = FindViewById<TextView>(Resource.Id.vehicle_price_of_park);
            PayAndOutButton = FindViewById<Button>(Resource.Id.btn_pay_and_out);
            PayAndOutButton.Click += btnPayAndOut_Click;
            dateOfDeparture = new DateTimeOffset(dateOfDepartureActual.DateTime, TimeSpan.FromHours(0));
        }

        private void GetExtras()
        {
            if(Intent.Extras.GetString("car") != null)
            {
                leavingCar = JsonConvert.DeserializeObject<Car>(Intent.Extras.GetString("car"));
                SetDependencies(leavingCar);
                SetLabels(leavingCar);
            }
            if(Intent.Extras.GetString("motorcycle") != null)
            {
                leavingMotorcycle = JsonConvert.DeserializeObject<Motorcycle>(Intent.Extras.GetString("motorcycle"));
                SetDependencies(leavingMotorcycle);
                SetLabels(leavingMotorcycle);
            }
        }

        private void SetLabels<T>(T vehicle)
        {
            Vehicle leavingVehicle;
            if (vehicle.GetType() == typeof(Car))
            {
                carServiceDomain.CalculatePriceOfPark(leavingCar, dateOfDeparture);
                leavingVehicle = leavingCar;
            }else
            {
                motorcycleServiceDomain.CalculatePriceOfPark(leavingMotorcycle, dateOfDeparture);
                leavingVehicle = leavingMotorcycle;
            }
            LeavingVehicleId.Text = leavingVehicle.VehicleId;
            LeavingVehicleDateOfEntry.Text = leavingVehicle.DateOfEntry.DateTime.ToString();
            LeavingVehicleDateOfDeparture.Text = leavingVehicle.DateOfDeparture.DateTime.ToString();
            LeavingVehiclePriceOfParking.Text = leavingVehicle.ParkingPrice.ToString();
        }

        private void btnPayAndOut_Click(object sender, EventArgs e)
        {
            if(carServiceDomain != null)
            {
                carServiceDomain.RemoveVechielFromDB(leavingCar);
            }
            if(motorcycleServiceDomain != null)
            {
                motorcycleServiceDomain.RemoveVechielFromDB(leavingMotorcycle);
            }
            Finish();
        }

        private void SetDependencies<T>(T vehicle)
        {
            dialogsService = ConfigureDependencies().Resolve<IDialogsService>();
            dialogsService.UserDialogsInit(this);
            if (vehicle.GetType() == typeof(Car))
            {
                carServiceDomain = ConfigureDependencies().Resolve<CarServiceDomain>();
            }
            if (vehicle.GetType() == typeof(Motorcycle))
            {
                motorcycleServiceDomain = ConfigureDependencies().Resolve<MotorcycleServiceDomain>();
            }
        }
    }
}

