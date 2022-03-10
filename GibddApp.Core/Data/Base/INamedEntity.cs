using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.Core.Data.Base
{
    public interface INamedEntity : IEntity
    {
        string Name { get; set; }
    }
}
