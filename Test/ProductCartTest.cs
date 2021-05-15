using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDarbas2021.Test
{
    public class ProductCartTest : BaseTest
    {
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
                .RemoveProductFromCart(0)
                .VerifyShoppingCartIsEmpty();
        }
    }
}
