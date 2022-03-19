using GibddApp.API.Data.Base;
using System.Text.Json.Serialization;

namespace GibddApp.API.Data
{
    [DbTableName("sex")]
    public class Sex : IEntity
    {
        private int _id = 0;

        [JsonPropertyName("id")]
        [DbAttributeName("id_sex")]
        public int Id { get => _id; set => _id = value; }

        [JsonPropertyName("name")]
        [DbAttributeName("type")]
        public string Name { get; set; } = nameof(Sex);
    }
}
