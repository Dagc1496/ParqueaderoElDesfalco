using System;
using Acr.UserDialogs;
using Android.App;

namespace ParqueaderoElDesfalco.Droid.Helpers.UserDialogsHelper
{
    public class UserDialogsHelper : IUserDialogsHelper
    {
        public void HideLoading()
        {
            UserDialogs.Instance.HideLoading();
        }

        public void ShowLoading()
        {
            UserDialogs.Instance.ShowLoading();
        }

        public void ShowMessage(string title, string message)
        {
            UserDialogs.Instance.AlertAsync(message, title, "Ok");
        }

        public void UserDialogsInit(Activity activity)
        {
            UserDialogs.Init(activity);
        }
    }
}
