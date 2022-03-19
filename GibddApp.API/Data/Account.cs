using GibddApp.API.Data.Base;
using System.Text.Json.Serialization;

namespace GibddApp.API.Data
{
    [DbTableName("account")]
    public class Account : IEntity
    {
        private int _id = 0;

        [DbAttributeName("id_account")]
        [JsonPropertyName("id")]
        public int Id { get => _id; set => _id = value; }

        [JsonPropertyName("login")]
        [DbAttributeName("login")]
        public string Login { get; set; } = nameof(Login);

        [JsonPropertyName("password")]
        [DbAttributeName("password")]
        public string Password { get; set; } = nameof(Password);


        [JsonPropertyName("accessCategoryId")]
        [DbAttributeName("id_access_category")]
        public int AccessCategoryId { get; set; } = 0;

        [JsonPropertyName("employeeId")]
        [DbAttributeName("id_worker")]
        public int EmployeeId { get; set; } = 0;
    }
}
