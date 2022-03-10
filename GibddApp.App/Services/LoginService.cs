using GibddApp.App.Exceptions;
using GibddApp.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.App.Services
{
    public class LoginService : Service
    {
        private IDataStorage _dataStorage;
        public LoginService(IDataStorage dataStorage, Privilege privilege) : base(privilege)
        {
            _dataStorage = dataStorage;
        }
        public async Task<Account> Login(string userName, string password)
        {
            try
            {
                Account acc = await _dataStorage.GetAccountAsync(userName, password);
                if (acc == null)
                {
                    throw new LoginServiceException("Login or password is incorrect");
                }
                SessionManager sessionManager = SessionManager.Instance;
                await sessionManager.CreateSessionFor(acc);
                return acc;
            }
            catch (Exception ex)
            {
                throw new LoginServiceException(ex.Message);
            }           
        }
    }
}
