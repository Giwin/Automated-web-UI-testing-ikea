using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDarbas2021.Page
{
    public class HomePage : BasePage
    {
        private const string urlPage = "https://www.ikea.lt/lt";
        private IWebElement searchField => Driver.FindElement(By.Id("header_searcher_desktop_input"));
        private IWebElement searchButton => Driver.FindElement(By.CssSelector("#headerMainToggler > div > div.container.headerMenuProducts > div.d-none.d-lg-block.m-0.searcher > div > div > button"));
        private IReadOnlyCollection<IWebElement> searchResults => Driver.FindElements(By.CssSelector("#contentWrapper > div.container > div > div.products_list.w-100.d-flex.flex-wrap > div:nth-child(1) > div"));
        // IList<IWebElement> searchResults => Driver.FindElements(By.ClassName("card px-3"));
        
        public HomePage(IWebDriver webdriver) : base(webdriver)
        {
        }
        public HomePage NavigateToDefaultPage()
        {
            if (Driver.Url != urlPage)
            {
                Driver.Url = urlPage;
            }
            return this;
        }
        public HomePage AcceptCookie()
        {

            Cookie myCookie = new Cookie("CookieConsent"
                , "{stamp:%27xGChaLlxWj47cmgNIwWN0ODOISlFh5A+bNoSqQjL/5hZMxaa988X1w==%27%2Cnecessary:true%2Cpreferences:false%2Cstatistics:false%2Cmarketing:false%2Cver:1%2Cutc:1621010391490%2Cregion:%27lt%27}"
                , "www.ikea.lt"
                , "/"
                , DateTime.Now.AddDays(5));

            Driver.Manage().Cookies.AddCookie(myCookie);
            Driver.Navigate().Refresh();
            return this;
        }
        public HomePage InsertSearchText(string searchText)
        {
            searchField.Clear();
            searchField.SendKeys(searchText);
            return this;
        }
        public HomePage ClickSearchButton()
        {
            searchButton.Click();
            return this;
        }
        public HomePage VerifySearchResults(string expectedText)
        {
            foreach (IWebElement element in searchResults)
            {
                Assert.IsTrue(element.Text.Contains(expectedText), $"Result is wrong. Result is expected to contain {expectedText} but actual result is {element.Text}");
            }
            //Assert.IsTrue(searchResults[0].Text.Contains(expectedText), $"Result is wrong. Expected value is {expectedText} but actual result is {searchResults[0].Text}");
            return this;
        }

    }
}
