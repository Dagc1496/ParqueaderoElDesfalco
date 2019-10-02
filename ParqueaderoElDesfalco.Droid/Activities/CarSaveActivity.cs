using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Autofac;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.ServiceDomain;

namespace ParqueaderoElDesfalco.Droid.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class CarSaveActivity : BaseActivity
    {

        private Car car;
        private EditText CarIdEditText;
        private DateTimeOffset dateOfEntry;
        private Button SaveCarButton;
        private CarServiceDomain carServiceDomain;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_save_car);

            CarIdEditText = FindViewById<EditText>(Resource.Id.car_id_entry);
            SaveCarButton = FindViewById<Button>(Resource.Id.btn_park_car);
            SaveCarButton.Click += btnSaveCar_Click;

            SetDependencies();
        }

        private void btnSaveCar_Click(object sender, EventArgs e)
        {
            if(CarIdEditText.Text != string.Empty && CarIdEditText.Text != null)
            {
                dateOfEntry = DateTimeOffset.Now;
                car = new Car(CarIdEditText.Text, dateOfEntry);
                carServiceDomain.SaveVechicleOnDb(car);
                Finish();
            }
            else
            {
                Toast.MakeText(this, Resource.String.prueba, ToastLength.Short).Show();
            }
        }

        private void SetDependencies()
        {
            carServiceDomain = ConfigureDependencies().Resolve<CarServiceDomain>();
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            if(CarIdEditText.Text != string.Empty)
            {
                outState.PutString("entryValue", CarIdEditText.Text);
            }
        }

        protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            base.OnRestoreInstanceState(savedInstanceState);
            if (savedInstanceState.GetString("entryValue") != null)
            {
                CarIdEditText.Text = savedInstanceState.GetString("entryValue");
            }
        }
    }
}