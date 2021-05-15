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
    public class SearchTest : BaseTest
    {
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
    }
}
