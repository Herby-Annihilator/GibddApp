using GibddApp.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.App.Services
{
    public class Service
    {
        protected Privilege _privilege;
        public bool CanExecute(PrivilegedEntity privilegedEntity)
        {
            if (privilegedEntity == null)
            {
                throw new ArgumentNullException(nameof(privilegedEntity));
            }
            return privilegedEntity.ContainsPrivilege(_privilege);
        }
        public Service(Privilege privilege)
        {
            _privilege = privilege;
        }
    }
}
