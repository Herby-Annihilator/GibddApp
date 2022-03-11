using GibddApp.Core.Data.Base;
using GibddApp.Core.Data.RoadAccidentParticipants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.Core.Data.Documents
{
    public class Document : IEntity
    {
        protected int _id;
        public virtual int Id { get => _id; set => _id = value; }
        protected string _serial;
        protected string _number;
        protected Citizen _owner;

        public virtual string Serial { get => _serial; set => _serial = value; }
        public virtual string Number { get => _number; set => _number = value; }
        public virtual Citizen Owner { get => _owner; set => _owner = value; }



        public Document(int id, string serial, string number, Citizen owner)
        {
            Serial = serial;
            Number = number;
            Id = id;
            Owner = owner;
        }
    }
}
