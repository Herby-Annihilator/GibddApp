using GibddApp.Core.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.Core.Data.Gibdd
{
    public class Employee : IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public Rank Rank { get; set; }
        public Position Position { get; set; }
        public Subdivision Subdivision { get; set; }
        private int _id;
        public int Id { get => _id; set => _id = value; }
    }
}
