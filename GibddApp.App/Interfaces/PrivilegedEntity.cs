using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.App.Interfaces
{
    public class PrivilegedEntity
    {
        protected Privilege _privilege;
        public virtual Privilege Privilege { get => _privilege; }

        public virtual void AddPrivilege(Privilege privilege) => _privilege |= privilege;

        public virtual void RemovePrivilege(Privilege privilege)
        {
            Privilege mask = ~privilege;
            _privilege &= mask;
        }

        public PrivilegedEntity() => _privilege = Privilege.None;

        public virtual bool ContainsPrivilege(Privilege privilege) => (_privilege &= privilege) == privilege;
    }
}
