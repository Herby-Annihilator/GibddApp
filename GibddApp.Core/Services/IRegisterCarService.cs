using GibddApp.Core.Data.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.Core.Services
{
    public interface IRegisterCarService
    {
        Task RegisterCarAsync(CarData carData);
        Task RegisterCarAsync(CarData carData, CancellationToken token);
    }
}
