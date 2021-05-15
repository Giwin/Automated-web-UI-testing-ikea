using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDarbas2021.Page
{
    public class FavoritesPage : BasePage
    {
        private const string urlPage = "";

        public FavoritesPage(IWebDriver webdriver) : base(webdriver)
        {
        }
        public FavoritesPage NavigateToDefaultPage()
        {
            if (Driver.Url != urlPage)
            {
                Driver.Url = urlPage;
            }
            return this;
        }
    }
}
