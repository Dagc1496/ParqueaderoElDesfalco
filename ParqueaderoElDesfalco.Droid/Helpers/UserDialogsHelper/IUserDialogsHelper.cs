using Android.App;

namespace ParqueaderoElDesfalco.Droid.Helpers.UserDialogsHelper
{
    public interface IUserDialogsHelper
    {
        void ShowMessage(string title, string message);
        void ShowLoading();
        void HideLoading();
        void UserDialogsInit(Activity activity);
    }
}
