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

        private string idToSaveCar = "but-000";
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
    }
}
