using GibddApp.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.App.Tests.TestMiddleware
{
    internal class DataStorageReturnsNullAccount : IDataStorage
    {
        public Task<Account> GetAccountAsync(string userName, string password)
        {
            return Task.Factory.StartNew(() => 
            {
                Account acc = null;
                return acc;
            });
        }
    }
}
