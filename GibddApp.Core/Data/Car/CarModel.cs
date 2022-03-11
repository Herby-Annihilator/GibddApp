using GibddApp.Core.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.Core.Data.Car
{
    public class CarModel : NamedEntity
    {
        public CarMark CarMark { get; set; }

        public CarModel(int id, string name, CarMark carMark) : base(name, id)
        {
            CarMark = carMark;
        }
    }
}
