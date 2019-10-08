using System;
using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;
namespace ParqueaderoElDesfalco.UITest.PageObjects
{
    public class SaveCarPageObject : BasePageObject
    {
        readonly Query parkCarButton;
        readonly Query carIdEditText;

        public SaveCarPageObject()
        {
            parkCarButton = x => x.Marked("btn_park_car");
            carIdEditText = x => x.Marked("car_id_entry");
        }

        public void WriteCarId(string carId)
        {
            app.WaitForElement(carIdEditText);
            app.Tap(carIdEditText);
            app.EnterText(carIdEditText, carId);
            app.DismissKeyboard();
        }

        public void TapSaveCarButton()
        {
            app.Tap(parkCarButton);
        }
    }
}
