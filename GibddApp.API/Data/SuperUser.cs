using System.Text.Json.Serialization;

namespace GibddApp.API.Data
{
    public class SuperUser
    {
        [JsonPropertyName("citizen")]
        public CustomCitizen CustomCitizen { get; set; }

        [JsonPropertyName("passport")]
        public Passport Passport { get; set; }

        [JsonPropertyName("driverLicense")]
        public DriverLicense DriverLicense { get; set; }
    }
}
