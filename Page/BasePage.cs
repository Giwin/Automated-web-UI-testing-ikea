﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDarbas2021
{
    public class BasePage
    {
        protected static IWebDriver Driver;
        public BasePage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        public WebDriverWait GetWait(int seconds = 10)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
        }
    }
}
