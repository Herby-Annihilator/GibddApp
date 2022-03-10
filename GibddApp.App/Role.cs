using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.App
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Privilege Privilege => _privilege;
        private Privilege _privilege = Privilege.None;

        public void AddPrivilege(Privilege privilege) => _privilege |= privilege;

        public void RemovePrivilege(Privilege privilege)
        {
            Privilege mask = ~privilege;
            _privilege &= mask;
        }

        public bool ContainsPrivilege(Privilege privilege) => (_privilege &= privilege) == privilege;
    }
}
