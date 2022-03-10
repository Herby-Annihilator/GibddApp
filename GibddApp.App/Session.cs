using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.App
{
    internal class Session
    {
        internal Account Account { get; set; }
        internal Guid SessionId { get; private set; }

        internal Session(Account account)
        {
            Account = account;
            SessionId = Guid.NewGuid();
        }
    }
}
