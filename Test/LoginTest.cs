using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDarbas2021.Test
{
    public class LoginTest : BaseTest
    {
        [Test]
        public static void TestUserLogin()
        {
            homePage.NavigateToDefaultPage()
                .AcceptCookie()
                .ClickLoginOrRegister()
                .EnterEmail(User.MyUser.TestUser.Email)
                .EnterPassword(User.MyUser.TestUser.Password)
                .ClickLogin();
            //not finished
        }
    }
}
