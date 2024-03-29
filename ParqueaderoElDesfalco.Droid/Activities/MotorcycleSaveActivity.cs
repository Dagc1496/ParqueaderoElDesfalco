﻿using System;
using System.Text.RegularExpressions;
using Android.App;
using Android.OS;
using Android.Widget;
using Autofac;
using ParqueaderoElDesfalco.Core.Domain.DomainExeptions;
using ParqueaderoElDesfalco.Core.Domain.Models;
using ParqueaderoElDesfalco.Core.ServiceDomain;
using ParqueaderoElDesfalco.Droid.Helpers.UserDialogsHelper;

namespace ParqueaderoElDesfalco.Droid.Activities
{
    [Activity(Label = "@string/motorcycle_parking", Theme = "@style/AppTheme")]
    public class MotorcycleSaveActivity : BaseActivity
    {

        #region Class vars and constants

        private IUserDialogsHelper userDialogsManager;
        private Motorcycle motorcycle;
        private EditText MotorcycleIdEditText;
        private EditText MotorcycleCilindrajeEditText;
        private readonly DateTimeOffset dateOfEntryActual = DateTimeOffset.Now;
        private DateTimeOffset dateOfEntry;
        private Button SaveMotorcycleButton;
        private MotorcycleServiceDomain motorcycleServiceDomain;

        #endregion

        #region Class methods

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
                try
                {
                    motorcycle = new Motorcycle(MotorcycleIdEditText.Text, dateOfEntry, Convert.ToInt32(MotorcycleCilindrajeEditText.Text));
                    motorcycleServiceDomain.SaveVechicleOnDb(motorcycle);
                    Finish();
                }
                catch (ParkingLotException)
                {
                    userDialogsManager.ShowMessage("Ups", Resources.GetString(Resource.String.parkinglot_full));
                }
                catch (VehicleIdException exceptionById)
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

        #endregion

        #region Lifecycle Methods

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_save_motorcycle);

            SetDependencies();
            ConfigViews();
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

        #endregion

        #region Dependency Injection

        private void SetDependencies()
        {
            motorcycleServiceDomain = ConfigureDependencies().Resolve<MotorcycleServiceDomain>();
            userDialogsManager = ConfigureDependencies().Resolve<IUserDialogsHelper>();
            userDialogsManager.UserDialogsInit(this);
        }

        #endregion
    }
}
