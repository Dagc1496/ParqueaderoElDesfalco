using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace ParqueaderoElDesfalco.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            name = (EditText)FindViewById(Resource.Id.edit_text_email);
            name.SetText(Resource.String.prueba);
            Log.Warn("Ciclo de vide", "onCreate");
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutString("name",name.Text);
            base.OnSaveInstanceState(outState);
            Log.Warn("Ciclo de vide","Guardando instancia");
        }

        protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            base.OnRestoreInstanceState(savedInstanceState);
            string test = savedInstanceState.GetString("name");
            Log.Warn("Ciclo de vide", "Restaurando instancia");
            Log.Warn("Ciclo de vide", test);
            name.Text = test;

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

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

