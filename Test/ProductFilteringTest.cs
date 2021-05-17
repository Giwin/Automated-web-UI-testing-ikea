using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDarbas2021.Test
{
    public class ProductFilteringTest : BaseTest
    {
        [Test]
        public static void TestColorCheckbox()
        {
            int index = 1;
            string color = "pilka";
            homePage.NavigateToDefaultPage()
                .AcceptCookie()
                .SelectCategory(index)
                .SelectColorFilter()
                .VerifyResults(color);
        }
        [Test]
        public static void TestSizeCheckbox()
        {
            int index = 0;
            string size = "150x200 cm";
            homePage.NavigateToDefaultPage()
                .AcceptCookie()
                .SelectCategory(index)
                .SelectSizeFilter()
                .VerifyResults(size);
        }
    }
}
