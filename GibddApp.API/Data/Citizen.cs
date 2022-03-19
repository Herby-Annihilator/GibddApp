using System.Text.Json.Serialization;
using System.Text.Json;
using GibddApp.API.Data.Base;

namespace GibddApp.API.Data
{
    [DbTableName("person")]
    public class Citizen : IEntity
    {
        private int _id = 0;
        [DbAttributeName("id_person")]
        [JsonPropertyName("id")]
        public int Id { get => _id; set => _id = value; }

        [JsonPropertyName("firstName")]
        [DbAttributeName("family")]
        public string FirstName { get; set; } = nameof(FirstName);

        [JsonPropertyName("lastName")]
        [DbAttributeName("name")]
        public string LastName { get; set; } = nameof(LastName);

        [JsonPropertyName("patronymic")]
        [DbAttributeName("patronymic")]
        public string Patronymic { get; set; } = "";

        [JsonPropertyName("workPlaceName")]
        [DbAttributeName("job_place")]
        public string WorkPlaceName { get; set; } = "";

        [JsonPropertyName("positionName")]
        [DbAttributeName("position")]
        public string PositionName { get; set; } = "";

        [JsonPropertyName("phone")]
        [DbAttributeName("phone")]
        public string Phone { get; set; } = "";

        [JsonPropertyName("sexId")]
        [DbAttributeName("id_sex")]
        public int SexId { get; set; } = 0;

        [JsonPropertyName("registrationAddressId")]
        [DbAttributeName("id_reg_addr")]
        public int RegistrationAddressId { get; set; } = 0;

        [JsonPropertyName("residentialAddressId")]
        [DbAttributeName("id_living_addr")]
        public int ResidentialAddressId { get; set; } = 0;  // адрес проживания

        [JsonPropertyName("workPlaceAddressId")]
        [DbAttributeName("id_job_addr")]
        public int WorkPlaceAddressId { get; set; } = 0;
        
    }
}
