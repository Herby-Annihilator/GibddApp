using GibddApp.App.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.App
{
    public class SessionManager
    {
        private List<Session> _sessionTable;
        private static SessionManager _instance;
        public static SessionManager Instance => _instance ??= new SessionManager();
        private SessionManager()
        {
            _sessionTable = new List<Session>();
        }

        public Task<Guid> CreateSessionFor(Account account)
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

        public Task<Account> GetAccountInSession(Guid sessionId)
        {
            return Task.Run(() => 
            {
                Session session = _sessionTable.Find((session) => session.SessionId == sessionId);
                if (session == null || session == default)
                    throw new SessionManagerException("There is no such session with specified sessionId");
                return session.Account;
            });
        }

        public Task<bool> CloseSessionWithSpecifiedUid(Guid uid) => Task.Run(
            () => _sessionTable.Remove(
                _sessionTable.Find(
                    (session) => session.SessionId == uid)
                )
            );
    }
}
