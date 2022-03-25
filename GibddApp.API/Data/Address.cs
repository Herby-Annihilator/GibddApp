using GibddApp.API.Data.Base;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GibddApp.API.Data
{
    [DbTableName("address")]
    public class Address : IEntity
    {
        private int _id = 0;

        [JsonPropertyName("id")]
        [DbAttributeName("id_address")]
        public int Id { get => _id; set => _id = value; }

        [DbAttributeName("country")]
        [JsonPropertyName("countryName")]
        public string CountryName { get; set; }

        [DbAttributeName("district")]
        [JsonPropertyName("regionName")]
        public string RegionName { get; set; }

        [DbAttributeName("location")]
        [JsonPropertyName("cityName")]
        public string CityName { get; set; }

        [DbAttributeName("street")]
        [JsonPropertyName("streetName")]
        public string StreetName { get; set; }

        [DbAttributeName("home_number")]
        [JsonPropertyName("houseNumber")]
        public int HouseNumber { get; set; }

        public bool EqualNotById(Address address)
        {
            if (address == null)
                return false;
            if (ReferenceEquals(this, address))
                return true;
            if (CountryName == address.CountryName
                && RegionName == address.RegionName
                && CityName == address.CityName
                && StreetName == address.StreetName
                && HouseNumber == HouseNumber)
                return true;
            return false;
        }
        
    }
}
