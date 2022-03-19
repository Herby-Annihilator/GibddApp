using GibddApp.API.Data.Base;
using System.Text.Json.Serialization;

namespace GibddApp.API.Data
{
    [DbTableName("role_accident")]
    public class RoleInRoadAccident : IEntity
    {
        private int _id = 0;

        [JsonPropertyName("id")]
        [DbAttributeName("id_role_accident")]
        public int Id { get => _id; set => _id = value; }

        [JsonPropertyName("roleName")]
        [DbAttributeName("name")]
        public string RoleName { get; set; } = nameof(RoleInRoadAccident);
    }
}
