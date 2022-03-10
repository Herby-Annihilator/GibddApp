﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.App.Interfaces
{
    public interface IDataStorage
    {
        Task<Account> GetAccountAsync(string userName, string password);
    }
}
