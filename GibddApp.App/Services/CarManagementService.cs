using GibddApp.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.App.Services
{
    public class CarManagementService : PrivilegedEntity
    {
        public CarManagementService()
        {
            _privilege = Privilege.AddCar | Privilege.RemoveCar | Privilege.EditCarData;
        }
    }
}
