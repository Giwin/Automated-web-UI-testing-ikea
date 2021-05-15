using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDarbas2021.Page
{
    public class UserPage : BasePage
    {
        private const string urlPage = "";

        public UserPage(IWebDriver webdriver) : base(webdriver)
        {
        }
        public UserPage NavigateToDefaultPage()
        {
            if (Driver.Url != urlPage)
            {
                Driver.Url = urlPage;
            }
            return this;
        }
    }
}
