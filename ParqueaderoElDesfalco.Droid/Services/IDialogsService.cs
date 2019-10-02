using Android.App;

namespace ParqueaderoElDesfalco.Droid.Services
{
    public interface IDialogsService
    {
        void ShowMessage(string title, string message);
        bool ShowConfirmation(string title, string message, string acceptText, string cancelText);
        void ShowLoading();
        void HideLoading();
        void UserDialogsInit(Activity activity);
    }
}
