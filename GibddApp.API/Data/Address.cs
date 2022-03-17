using System.Text.Json;
using System.Text.Json.Serialization;

namespace GibddApp.API.Data
{
    public class Address
    {
        [JsonPropertyName("countryName")]
        public string CountryName { get; set; }

        [JsonPropertyName("regionName")]
        public string RegionName { get; set; }

        [JsonPropertyName("cityName")]
        public string CityName { get; set; }

        [JsonPropertyName("streetName")]
        public string StreetName { get; set; }

        [JsonPropertyName("houseNumber")]
        public int houseNumber { get; set; }
    }
}
