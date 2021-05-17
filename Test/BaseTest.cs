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
    public class BaseTest
    {
        protected static IWebDriver driver;
        public static HomePage homePage;
        public static ShoppingCartPage shoppingCartPage;
        public static UserPage userPage;


        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetChromeDriver();
            driver = CustomDriver.GetFirefoxDriver();
            homePage = new HomePage(driver);
            shoppingCartPage = new ShoppingCartPage(driver);
            userPage = new UserPage(driver);
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
