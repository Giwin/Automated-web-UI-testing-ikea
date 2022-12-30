using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDarbas2021.Driver
{
    class CustomDriver
    {
        public static IWebDriver GetChromeDriver()
        {
            return GetDriver(Browsers.Chrome);
        }

        public static IWebDriver GetFirefoxDriver()
        {
            return GetDriver(Browsers.Firefox);
        }

        public static IWebDriver GetEdgeDriver()
        {
            return GetDriver(Browsers.Edge);
        }

        private static IWebDriver GetDriver(Browsers browserName)
        {
            IWebDriver webdriver;

            switch (browserName)
            {
                case Browsers.Chrome:
                    webdriver = new ChromeDriver();
                    break;
                case Browsers.Firefox:
                    webdriver = new FirefoxDriver();
                    break;
                default:
                    webdriver = new ChromeDriver();
                    break;
            }
            //webdriver.Manage().Window.Maximize();
            //webdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return webdriver;
        }

    }
}
