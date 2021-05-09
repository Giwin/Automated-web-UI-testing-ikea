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
        private IWebElement searchField => Driver.FindElement(By.Id("header_searcher_desktop_input"));
        private IWebElement searchButton => Driver.FindElement(By.CssSelector("#headerMainToggler > div > div.container.headerMenuProducts > div.d-none.d-lg-block.m-0.searcher > div > div > button"));
        private IReadOnlyCollection<IWebElement> searchResults => Driver.FindElements(By.CssSelector("#contentWrapper > div.container > div > div.products_list.w-100.d-flex.flex-wrap > div:nth-child(1) > div"));
        // IList<IWebElement> searchResults => Driver.FindElements(By.ClassName("card px-3"));

        public HomePage(IWebDriver webDriver) : base(webDriver)
        {
            Driver = webDriver;
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
