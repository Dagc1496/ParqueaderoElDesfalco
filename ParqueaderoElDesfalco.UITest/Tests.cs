using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace ParqueaderoElDesfalco.UITest
{
    [TestFixture]
    public class Tests
    {
        IApp app;
        private string carToSaveId;

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp();
        }

        /*
        [Test]
        public void AppLaunches()
        {
            app.Repl();
        }
        */

        [Test]
        public void SaveCarTest()
        {
            //Arrange, Act
            SaveCar();

            //Assert
            Assert.AreEqual(carToSaveId, app.Query(q => q.Marked("car_id_textView")).First().Text);
        }

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
    }
}
