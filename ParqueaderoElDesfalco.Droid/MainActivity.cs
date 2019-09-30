using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace ParqueaderoElDesfalco.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Log.Warn("Ciclo de vide", "onCreate");
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            Log.Warn("Ciclo de vide","Guardando instancia");
        }

        protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            base.OnRestoreInstanceState(savedInstanceState);
            Log.Warn("Ciclo de vide", "Restaurando instancia");
        }

        protected override void OnStart()
        {
            base.OnStart();
            Log.Warn("Ciclo de vide", "onStart");
        }

        protected override void OnPause()
        {
            base.OnPause();
            Log.Warn("Ciclo de vide", "onPause");
        }

        protected override void OnResume()
        {
            base.OnResume();
            Log.Warn("Ciclo de vide", "onResume");
        }

        protected override void OnRestart()
        {
            base.OnRestart();
            Log.Warn("Ciclo de vide", "onRestart");
        }

        protected override void OnStop()
        {
            base.OnStop();
            Log.Warn("Ciclo de vide", "onPause");
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Log.Warn("Ciclo de vide", "onDestroy");
        }
    }
}

