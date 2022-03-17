using System.Text.Json.Serialization;
using System.Text.Json;

namespace GibddApp.API.Data
{
    public class UserData
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("patronymic")]
        public string Patronymic { get; set; }

        [JsonPropertyName("workPlaceName")]
        public string WorkPlaceName { get; set; }

        [JsonPropertyName("position")]
        public string Position { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("registrationAddress")]
        public Address RegistrationAddress { get; set; }

        [JsonPropertyName("residentialAddress")]
        public Address ResidentialAddress { get; set; }  // адрес проживания

        [JsonPropertyName("workPlaceAddress")]
        public Address WorkPlaceAddress { get; set; }
    }
}
