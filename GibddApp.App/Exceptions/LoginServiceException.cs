using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.App.Exceptions
{
    public class LoginServiceException : Exception
    {
        public LoginServiceException(string message = "Login Error") : base(message)
        {

        }

        public LoginServiceException(string message, Exception inner) : base(message, inner) { }
    }
}
