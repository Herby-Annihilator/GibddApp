using GibddApp.Core.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.Core.Data.Car
{
    public class CarMark : NamedEntity
    {
        public ICollection<CarModel> Models { get; set; }

        public CarMark(string name, int id, ICollection<CarModel> models)
        {
            Name = name;
            Id = id;
            Models = models;
        }
    }
}
