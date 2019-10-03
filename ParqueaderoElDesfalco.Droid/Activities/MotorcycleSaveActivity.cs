using System;
using System.Text.RegularExpressions;
using Android.App;
using Android.OS;
using Android.Widget;
using Autofac;
using ParqueaderoElDesfalco.Core.Domain;
using ParqueaderoElDesfalco.Core.Domain.DomainExeptions;
using ParqueaderoElDesfalco.Core.ServiceDomain;
using ParqueaderoElDesfalco.Droid.Services;

namespace ParqueaderoElDesfalco.Droid.Activities
{
    [Activity(Label = "@string/motorcycle_parking", Theme = "@style/AppTheme")]
    public class MotorcycleSaveActivity : BaseActivity
    {
        private IDialogsService dialogsService;
        private Motorcycle motorcycle;
        private EditText MotorcycleIdEditText;
        private EditText MotorcycleCilindrajeEditText;
        private readonly DateTimeOffset dateOfEntryActual = DateTimeOffset.Now;
        private DateTimeOffset dateOfEntry;
        private Button SaveMotorcycleButton;
        private MotorcycleServiceDomain motorcycleServiceDomain;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_save_motorcycle);

            SetDependencies();
            ConfigViews();
        }

        private void ConfigViews()
        {
            MotorcycleIdEditText = FindViewById<EditText>(Resource.Id.motorcycle_id_entry);
            MotorcycleCilindrajeEditText = FindViewById<EditText>(Resource.Id.motorcycle_cilindraje_entry);
            SaveMotorcycleButton = FindViewById<Button>(Resource.Id.btn_park_motorcycle);
            SaveMotorcycleButton.Click += btnSaveMotorcycle_Click;
        }

        private void btnSaveMotorcycle_Click(object sender, EventArgs e)
        {
            if (EntrysAreOk())
            {
                dateOfEntry = new DateTimeOffset(dateOfEntryActual.DateTime, TimeSpan.FromHours(0));
                motorcycle = new Motorcycle(MotorcycleIdEditText.Text, dateOfEntry, Convert.ToInt32(MotorcycleCilindrajeEditText.Text));
                try
                {
                    motorcycleServiceDomain.SaveVechicleOnDb(motorcycle);
                    Finish();
                }
                catch (ParkingLotException)
                {
                    dialogsService.ShowMessage("Ups", Resources.GetString(Resource.String.parkinglot_full));
                }
                catch (VehicleIdException exceptionById)
                {
                    if (exceptionById.Message == "ByDay")
                    {
                        dialogsService.ShowMessage("Ups", Resources.GetString(Resource.String.forbidden_day));
                    }
                    else
                    {
                        dialogsService.ShowMessage("Hmmm", Resources.GetString(Resource.String.incoherent_id));
                    }
                }
            }
        }

        private void SetDependencies()
        {
            motorcycleServiceDomain = ConfigureDependencies().Resolve<MotorcycleServiceDomain>();
            dialogsService = ConfigureDependencies().Resolve<IDialogsService>();
            dialogsService.UserDialogsInit(this);
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            if (EntrysAreOk())
            {
                outState.PutString("entryIdValue", MotorcycleIdEditText.Text);
                outState.PutString("entryCilindrajeValue", MotorcycleCilindrajeEditText.Text);
            }
        }

        protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            base.OnRestoreInstanceState(savedInstanceState);
            if (savedInstanceState.GetString("entryValue") != null)
            {
                MotorcycleIdEditText.Text = savedInstanceState.GetString("entryIdValue");
                MotorcycleCilindrajeEditText.Text = savedInstanceState.GetString("entryCilindrajeValue");
            }
        }

        private bool EntrysAreOk()
        {
            if (!string.IsNullOrEmpty(MotorcycleIdEditText.Text))
            {
                if (!string.IsNullOrEmpty(MotorcycleCilindrajeEditText.Text) && Regex.IsMatch(MotorcycleCilindrajeEditText.Text, @"^\d+$"))
                {
                    return true;
                }
                MotorcycleCilindrajeEditText.Error = Resources.GetString(Resource.String.empty_motorcycle_cilindraje);
            }
            MotorcycleIdEditText.Error = Resources.GetString(Resource.String.empty_vehicle_id);
            return false;
        }
    }
}
