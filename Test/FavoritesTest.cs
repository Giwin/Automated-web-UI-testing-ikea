using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDarbas2021.Test
{
    public class FavoritesTest : BaseTest
    {
        [Test]
        public static void TestAddToFavorites()
        {
            int index = 0;
            homePage.NavigateToDefaultPage()
                .AcceptCookie();
            string productName = homePage.GetProductTitle(index);
            homePage.OpenProductQuickView(index)
                .AddToFavorites();
            //.OpenFavoritedProductsList();
            favoritesPage.NavigateToDefaultPage();
                homePage.EnterEmail(User.MyUser.TestUser.Email)
                .EnterPassword(User.MyUser.TestUser.Password)
                .ClickLogin();
            favoritesPage.NavigateToDefaultPage()
                .VerifyProductWasAddedToFavorites(productName)
                .RemoveProductsFromFavorites()
                .VerifyShoppingCartIsEmpty();
            // ?????????????
        }
    }
}
