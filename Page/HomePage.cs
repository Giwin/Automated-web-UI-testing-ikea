using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaigiamasisDarbas2021.Page
{
    public class HomePage : BasePage
    {
        private const string urlPage = "https://www.ikea.lt/lt";
        private IWebElement searchField => Driver.FindElement(By.Id("header_searcher_desktop_input"));
        private IWebElement searchButton => Driver.FindElement(By.ClassName("input-group-append"));
        private IReadOnlyCollection<IWebElement> productCards => Driver.FindElement(By.CssSelector(".productList"))
            .FindElements(By.CssSelector(".card"));
        private IWebElement addToCartButton => Driver.FindElement(By.CssSelector("#sidenav > div > div.card-body > div > div > div:nth-child(2) > div > div.itemActionBlock > div.itemButtons > button.addToCart.btn.btn-yellow.btn-block.btn-icon.text-white"));
        private IWebElement goToCartButton => Driver.FindElement(By.CssSelector("#modal > div > div > div.modal-footer.d-block > div.row.m-0 > div > div > button.goToCart.btn.btn-yellow.btn-icon.text-white"));
        private IWebElement addToFavorites => Driver.FindElement(By.CssSelector("#sidenav > div > div.card-body > div > div > div:nth-child(2) > div > div.itemActionBlock > div.itemButtons > button.addFavorites.btn.btn-block.btn-icon"));
        private IWebElement closeProductModal => Driver.FindElement(By.ClassName("close-legend"));
        private IWebElement openFavoritesButton => Driver.FindElement(By.CssSelector("#headerMainToggler > div > div.container.headerMenuProducts > div.d-none.d-lg-block.ml-4.favourites-notification > a"));
        private IWebElement loginOrRegisterButton => Driver.FindElement(By.XPath("//*[text()='Prisijungti arba registruotis']"));
        private IWebElement logoutButton => Driver.FindElement(By.XPath("//*[text()='Atsijungti']"));
        private IWebElement emailField => Driver.FindElement(By.Id("loginForm_email"));
        private IWebElement passwordField => Driver.FindElement(By.Id("loginForm_password"));
        private IWebElement loginButton => Driver.FindElement(By.Id("btnSubmitLogin"));


        private IWebElement addToFavoritesButton => Driver.FindElement(By.CssSelector("#sidenav > div > div.card-body > div > div > div:nth-child(2) > div > div.itemActionBlock > div.itemButtons > button.addFavorites.btn.btn-block.btn-icon"));
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
            Assert.IsTrue(
                productCards.ElementAt(0).Text.Contains(expectedText),
                $"Result is wrong. Result is expected to contain {expectedText} but actual result is {productCards.ElementAt(0).Text}"
            );
            return this;
        }
        public HomePage OpenProductQuickView(int index)
        {
            productCards.ElementAt(index).FindElement(By.XPath("//*[text()='Greita peržiūra']")).Click();
            return this;
        }
        public string GetProductTitle(int index)
        {
            return productCards.ElementAt(index).FindElement(By.XPath("//*[@data-title]")).Text;
        }
        public HomePage AddProductToCart()
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(addToCartButton));
            addToCartButton.Click();
            return this;
        }
        public ShoppingCartPage GoToCart()
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(goToCartButton));
            Thread.Sleep(200);
            goToCartButton.Click();
            return new ShoppingCartPage(Driver);
        }
        public HomePage AddToFavorites()
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(addToFavorites));
            addToFavorites.Click();
            closeProductModal.Click();
            return this;
        }
        public HomePage OpenFavoritedProductsList()
        {
            //GetWait().Until(ExpectedConditions.ElementToBeClickable(openFavoritesButton));
            //Thread.Sleep(200);
            openFavoritesButton.Click();
            return this;
        }
        public HomePage ClickLoginOrRegister()
        {
            loginOrRegisterButton.Click();
            return this;
        }
        public HomePage EnterEmail(string username)
        {
            emailField.SendKeys(username);
            return this;
        }
        public HomePage EnterPassword(string password)
        {
            passwordField.SendKeys(password);
            return this;
        }
        public HomePage ClickLogin()
        {
            loginButton.Click();
            return this;
        }
        public HomePage VerifyLogoutButtonIsPresent()
        {
            Assert.IsNotNull(logoutButton);
            return this;
        }
        public HomePage ClickLogout()
        {
            logoutButton.Click();
            return this;
        }

    }
}
