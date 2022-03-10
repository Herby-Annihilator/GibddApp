using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.App.Exceptions
{
    public class SessionManagerException : Exception
    {
        public SessionManagerException(string message = "Session Manager Exception") : base(message)
        {

        }

        public SessionManagerException(string message, Exception inner) : base(message, inner) { }
    }
}
