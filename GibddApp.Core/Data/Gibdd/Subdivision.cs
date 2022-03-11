using GibddApp.Core.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.Core.Data.Gibdd
{
    public class Subdivision : NamedEntity
    {
        public Subdivision(Address address, string name, int id) : base(name, id)
        {
            Address = address;
        }

        public Address Address { get; set; }
    }
}
