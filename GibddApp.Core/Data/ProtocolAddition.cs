using GibddApp.Core.Data.Car;
using GibddApp.Core.Data.Gibdd;
using GibddApp.Core.Data.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.Core.Data
{
    public class ProtocolAddition
    {
        public string DamageDescription { get; set; }
        public CarData DamagedCar { get; set; }
    }
}
