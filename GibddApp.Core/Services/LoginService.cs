using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GibddApp.Core.Data;
using GibddApp.Core.Services.Base;

namespace GibddApp.Core.Services
{
    public abstract class LoginService : IService
    {
        public virtual bool CanExecute() => true;

        public abstract Account Login(string userName, string password);
        public async virtual Task<Account> LoginAsync(string userName, string password, CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                token.ThrowIfCancellationRequested();
            }
            Task<Account> task = Task.Factory.StartNew(() => Login(userName, password), token);
            return await task;
        }
    }
}
