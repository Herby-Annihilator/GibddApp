using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.App
{
    internal class SessionManager
    {
        private List<Session> _sessionTable;
        private static SessionManager _instance;
        internal static SessionManager Instance => _instance ??= new SessionManager();
        private SessionManager()
        {
            _sessionTable = new List<Session>();
        }

        internal Task<Guid> CreateSessionFor(Account account)
        {
            Task<Guid> task = Task.Run(() => 
            {
                Guid guid;
                if (_sessionTable.Any((session) => session.Account.Id == account.Id))
                {
                    throw new Exception("Session is already exists. Please, finish your session!");
                }
                var session = new Session(account);
                _sessionTable.Add(session);
                guid = session.SessionId;
                return guid;
            });
            return task;
        }
    }
}
