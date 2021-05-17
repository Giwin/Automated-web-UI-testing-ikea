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
        private const string urlPage = "https://www.ikea.lt/lt/client";
        private IWebElement emailField => Driver.FindElement(By.Id("loginForm_email"));
        private IWebElement passwordField => Driver.FindElement(By.Id("loginForm_password"));
        private IWebElement loginButton => Driver.FindElement(By.Id("btnSubmitLogin"));

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
        public UserPage EnterEmail(string username)
        {
            emailField.SendKeys(username);
            return this;
        }
        public UserPage EnterPassword(string password)
        {
            passwordField.SendKeys(password);
            return this;
        }
        public UserPage ClickLogin()
        {
            loginButton.Click();
            return this;
        }
    }
}
