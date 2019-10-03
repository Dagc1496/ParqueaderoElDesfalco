using System;
using Xamarin.UITest;

namespace ParqueaderoElDesfalco.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp()
        {

            return ConfigureApp
                .Android
                // TODO: Update this path to point to your Android app and uncomment the
                // code if the app is not included in the solution.
                //.ApkFile ("../../../Droid/bin/Debug/xamarinforms.apk")
                .StartApp();
        }
    }
}
