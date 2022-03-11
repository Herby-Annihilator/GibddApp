using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.App
{
    public class Account
    {
        public int Id { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public Account(int id, string userName, string password)
        {
            Id = id;
            UserName = userName;
            Password = password;
        }
    }
}
