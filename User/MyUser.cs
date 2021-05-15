using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDarbas2021.User
{
    public class MyUser
    {
        public string Email;
        public string Password;
        public MyUser(string email, string password)
        {
            Email = email;
            Password = password;
        }
        public static MyUser TestUser = new MyUser("test.jd1999@gmail.com", "TestTest1@");
    }
}
