using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.App
{
    /// <summary>
    /// Privilege. Values of a power of two are allowed 
    /// </summary>
    [Flags]
    public enum Privilege : uint
    {
        None = 0,

        AddUser = 1,
        RemoveUser = 2,
        EditUserData = 4,

        AddCar = 8,
        RemoveCar = 16,
        EditCarData = 32,

        CreateProtocol = 64,
        RemoveProtocol = 128,
        EditProtocolData = 256,

        CreateAccount = 512,
        RemoveAccount = 1024,
        EditAccountData = 2048,

        Login = 4096,
        Logout = 8192,

        EditHelpInformation = 16384,

        
        // Add additional privileges

        All = 0xFFFFFFFF
    }
}
