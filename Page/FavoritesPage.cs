using NUnit.Framework;
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
        private const string urlPage = "https://www.ikea.lt/lt/client/account/favourites";
        private IList<IWebElement> favoritedItemList => Driver.FindElements(By.ClassName("favourites-list_item"));
        private IWebElement selectAllButton => Driver.FindElement(By.XPath("//*[text()='Pažymėti visus']"));
        private IWebElement removeSelectedButton => Driver.FindElement(By.XPath("//*[text()='Pašalinti pažymėtas']"));


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
        public FavoritesPage VerifyProductWasAddedToFavorites(string expectedText)
        {
            Assert.IsTrue(
                favoritedItemList[0].Text.Contains(expectedText),
                $"Result is wrong. Result is expected to contain {expectedText} but actual result is {favoritedItemList[0].Text}"
            );
            return this;
        }
        public FavoritesPage RemoveProductsFromFavorites()
        {
            selectAllButton.Click();
            removeSelectedButton.Click();
            return this;
        }
        public FavoritesPage VerifyShoppingCartIsEmpty()
        {
            Assert.IsEmpty(favoritedItemList);
            return this;
        }
    }
}
