using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.Core.Services
{
    public interface ILoginService
    {
        Task LoginAsync(string username, string password);
        Task LoginAsync(string username, string password, CancellationToken token);
    }
}
