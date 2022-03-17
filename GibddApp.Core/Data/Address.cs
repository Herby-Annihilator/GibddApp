using GibddApp.Core.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.Core.Data
{
    public class Address : IEntity
    {
        public string CountyName { get; set; }
        public string RegionName { get; set; }
        public string CityName { get; set; }
        public string StreetName { get; set; }
        public int HomeNumber { get; set; }
        private int _id;
        public int Id { get =>_id; set => _id = value; }

        public Address(string countyName, string regionName, string cityName, string streetName, int homeNumber = -1)
        {
            CountyName = countyName;
            RegionName = regionName;
            CityName = cityName;
            StreetName = streetName;
            HomeNumber = homeNumber;
        }

        public static Address Invalid()
        {
            Address address = new Address("invalid", "invalid", "invalid", "invalid");
            return address;
        }

        public override string ToString() => $"{CountyName}, {RegionName}, {CityName}, {StreetName}, {HomeNumber}";
    }
}
