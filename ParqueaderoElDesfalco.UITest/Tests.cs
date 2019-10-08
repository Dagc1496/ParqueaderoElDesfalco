using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using ParqueaderoElDesfalco.UITest.PageObjects;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace ParqueaderoElDesfalco.UITest
{
    [TestFixture]
    public class Tests
    {

        private string idToSaveCar = "Placa automatica";
        private MainPageObject mainPageObject;
        private SaveCarPageObject saveCarPageObject;

        [Test]
        public void SaveCarTest()
        {
            //Arrange
            mainPageObject = new MainPageObject();
            saveCarPageObject = new SaveCarPageObject();
            mainPageObject.GoToSaveCarActivity();
            saveCarPageObject.WriteCarId(idToSaveCar);

            //Act
            saveCarPageObject.TapSaveCarButton();

            //Assert
            mainPageObject.CheckCarListForCreated(idToSaveCar);
        }

        /*
        [Test]
        public void RemoveCarTest()
        {
            //Arrange
            SaveCar();
            app.Tap(x => x.Marked(app.Query(q => q.Marked("car_id_textView")).First().Text));

            //Act
            app.Tap(x => x.Marked("btn_pay_and_out"));

            //Assert
            Assert.IsEmpty(app.Query(q => q.Marked("car_id_textView")));
        }

        private void SaveCar()
        {
            carToSaveId = "Placa Automatica";
            app.Tap(x => x.Marked("btn_park_new_car"));
            app.Tap(x => x.Marked("car_id_entry"));
            app.EnterText(x => x.Marked("car_id_entry"), carToSaveId);
            app.DismissKeyboard();

            app.Tap(x => x.Marked("btn_park_car"));
        }
        */
    }
}
