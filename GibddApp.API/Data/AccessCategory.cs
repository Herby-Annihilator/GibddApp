using GibddApp.API.Data.Base;
using System.Text.Json.Serialization;

namespace GibddApp.API.Data
{
    [DbTableName("access_category")]
    public class AccessCategory : IEntity
    {
        private int _id = 0;

        [JsonPropertyName("id")]
        [DbAttributeName("id_access_category")]
        public int Id { get => _id; set => _id = value; }

        [JsonPropertyName("name")]
        [DbAttributeName("name")]
        public string Name { get; set; } = nameof(AccessCategory);
    }
}
