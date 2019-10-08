using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace ParqueaderoElDesfalco.UITest.PageObjects
{
    public class MainPageObject : BasePageObject
    {
        readonly Query saveCarButton;
        readonly Query carIdtextView;

        public MainPageObject()
        {
            saveCarButton = x => x.Marked("btn_park_new_car");
            carIdtextView = x => x.Marked("car_id_textView");
        }

        public void GoToSaveCarActivity()
        {
            app.Tap(saveCarButton);
        }

        public MainPageObject CheckCarListForCreated(string createdCar)
        {
            Assert.AreEqual(createdCar, app.Query(carIdtextView).First().Text);
            return this;
        }
    }
}
