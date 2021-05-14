using BaigiamasisDarbas2021.Driver;
using BaigiamasisDarbas2021.Page;
using BaigiamasisDarbas2021.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDarbas2021.Test
{
    class BaseTest
    {
        protected static IWebDriver driver;
        public static HomePage homePage;

        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetChromeDriver();
            //driver = CustomDriver.GetFirefoxDriver();
            homePage = new HomePage(driver);
        }
        [TearDown]
        public static void TearDownAttribute()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.TakeScreenshot(driver);
            }
        }
        [OneTimeTearDown]
        public static void TearDown()
        {
            driver.Quit();
        }
    }
}
