﻿using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Autofac;
using ParqueaderoElDesfalco.Core.Domain.DomainExeptions;
using ParqueaderoElDesfalco.Core.Domain.DomainObjects;
using ParqueaderoElDesfalco.Core.ServiceDomain;
using ParqueaderoElDesfalco.Droid.Helpers.UserDialogsHelper;

namespace ParqueaderoElDesfalco.Droid.Activities
{
    [Activity]
    public class CarSaveActivity : BaseActivity
    {
        private IUserDialogsHelper userDialogsManager;
        private Car car;
        private EditText CarIdEditText;
        private readonly DateTimeOffset dateOfEntryActual = DateTimeOffset.Now;
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
                dateOfEntry = new DateTimeOffset(dateOfEntryActual.DateTime, TimeSpan.FromHours(0));
                try
                {
                    car = new Car(CarIdEditText.Text, dateOfEntry);
                    carServiceDomain.SaveVechicleOnDb(car);
                    Finish();
                }
                catch (ParkingLotException)
                {
                    userDialogsManager.ShowMessage("Ups", Resources.GetString(Resource.String.parkinglot_full));
                }catch (VehicleIdException exceptionById)
                {
                    if (exceptionById.Message == "ByDay")
                    {
                        userDialogsManager.ShowMessage("Ups", Resources.GetString(Resource.String.forbidden_day));
                    }
                    else
                    {
                        userDialogsManager.ShowMessage("Hmmm", Resources.GetString(Resource.String.incoherent_id));
                    }
                }
            }
            else
            {
                CarIdEditText.Error = Resources.GetString(Resource.String.empty_vehicle_id);
            }
        }

        private void SetDependencies()
        {
            carServiceDomain = ConfigureDependencies().Resolve<CarServiceDomain>();
            userDialogsManager = ConfigureDependencies().Resolve<IUserDialogsHelper>();
            userDialogsManager.UserDialogsInit(this);
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
