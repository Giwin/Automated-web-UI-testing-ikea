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
    public class ShoppingCartPage : BasePage
    {
        private const string urlPage = "https://www.ikea.lt/lt/shoppingcart/shoppingcart";
        private IList<IWebElement> itemList => Driver.FindElements(By.ClassName("itemProduct"));

        public ShoppingCartPage(IWebDriver webdriver) : base(webdriver)
        {
        }
        public ShoppingCartPage NavigateToDefaultPage()
        {
            if (Driver.Url != urlPage)
            {
                Driver.Url = urlPage;
            }
            return this;
        }
        public ShoppingCartPage VerifyProductWasAddedToCart(string expectedText)
        {
            Assert.IsTrue(
                itemList[0].Text.Contains(expectedText),
                $"Result is wrong. Result is expected to contain {expectedText} but actual result is {itemList[0].Text}"
            );
            return this;
        }
        public ShoppingCartPage RemoveProductFromCart(int index)
        {
            itemList[index].FindElement(By.XPath("//*[text()='Pašalinti']")).Click();
            return this;
        }
    }
}
