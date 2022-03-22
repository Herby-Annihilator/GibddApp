using System.Text.Json.Serialization;

namespace GibddApp.API.Data
{
    public class CustomCitizen : Citizen
    {
        [JsonPropertyName("registrationAddress")]
        public Address RegistrationAddress { get; set; } 

        [JsonPropertyName("residentialAddress")]
        public Address ResidentialAddress { get; set; }   // адрес проживания

        [JsonPropertyName("workPlaceAddress")]
        public Address WorkPlaceAddress { get; set; }
        
        public static CustomCitizen FromCitizen(Citizen citizen)
        {
            CustomCitizen customCitizen = new CustomCitizen()
            {
                FirstName = citizen.FirstName,
                LastName = citizen.LastName,
                Patronymic = citizen?.Patronymic,
                Id = citizen.Id,
                Phone = citizen?.Phone,
                PositionName = citizen?.PositionName,
                RegistrationAddressId = citizen.RegistrationAddressId,
                ResidentialAddressId = citizen.ResidentialAddressId,
                SexId = citizen.SexId,
                WorkPlaceAddressId = citizen.WorkPlaceAddressId,
                WorkPlaceName = citizen?.WorkPlaceName
            };
            return customCitizen;
        }
    }
}
