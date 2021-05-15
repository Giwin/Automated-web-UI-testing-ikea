using BaigiamasisDarbas2021.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDarbas2021.Test
{
    public class HomeTest : BaseTest
    {
        //[Order(1)]
        //[Test]
        //public static void AcceptCookies()
        //{
        //    homePage.NavigateToDefaultPage().
        //        AcceptCookie();
        //}
        [Order(1)]
        [Test]
        public static void TestSearch()
        {
            string searchText = "sofa-lova";
            homePage.NavigateToDefaultPage()
                .AcceptCookie()
                .InsertSearchText(searchText)
                .ClickSearchButton()
                .VerifySearchResults(searchText);
        }
        [Order(2)]
        [Test]
        public static void TestAddProductToCart()
        {
            int index = 0;
            homePage.NavigateToDefaultPage()
                .AcceptCookie();
            string productName = homePage.GetProductTitle(index);
            homePage.OpenProductQuickView(index)
                .AddProductToCart()
                .GoToCart()
                .VerifyProductWasAddedToCart(productName)
                .RemoveProductFromCart(0);
        }
    }
}
