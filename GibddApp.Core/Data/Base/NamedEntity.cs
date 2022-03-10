using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.Core.Data.Base
{
    public class NamedEntity : INamedEntity
    {
        protected string _name;
        protected int _id;
        public virtual string Name { get => _name; set => _name = (string)value.Clone(); }
        public virtual int Id { get => _id; set => _id = value; }
    }
}
