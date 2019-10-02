using System;
using Acr.UserDialogs;
using Android.App;
using Android.Content;

namespace ParqueaderoElDesfalco.Droid.Services
{
    public class DialogsService : IDialogsService
    {
        public void HideLoading()
        {
            UserDialogs.Instance.HideLoading();
        }

        public bool ShowConfirmation(string title, string message, string acceptText, string cancelText)
        {
            throw new NotImplementedException();
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
