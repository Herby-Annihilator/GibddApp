using GibddApp.Core.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.Core.Data.Car
{
    public class CarData : IEntity
    {
        public CarMark Mark { get; set; }
        public CarModel Model { get; set; }
        public DateTime CreationDate { get; set; }

        public int Weight { get; set; }
        public int MaxWeight { get; set; }

        public string ChassisNumber { get; set; }
        public string BodyNumber { get; set; }

        public string VIN { get; set; }
        public DateTime RegistrationDate { get; set; }

        public NamedEntity CarCategory { get; set; }
        private int _id;
        public int Id { get => _id; set => _id = value; }
    }
}
