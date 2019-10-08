using System;
using Xamarin.UITest;

namespace ParqueaderoElDesfalco.UITest.PageObjects
{
    public class BasePageObject
    {
        protected IApp app = AppInitializer.StartApp();
    }
}
