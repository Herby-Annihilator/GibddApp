using GibddApp.Core.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.Core.Data.Common
{
    public class Color : NamedEntity
    {
        public Color(string name, int id) : base(name, id)
        {
        }
    }
}
