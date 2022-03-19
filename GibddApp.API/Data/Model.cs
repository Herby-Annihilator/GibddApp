using GibddApp.API.Data.Base;
using System.Text.Json.Serialization;

namespace GibddApp.API.Data
{
    [DbTableName("model")]
    public class Model : IEntity
    {
        private int _id = 0;

        [JsonPropertyName("id")]
        [DbAttributeName("id_model")]
        public int Id { get => _id; set => _id = value; }

        [JsonPropertyName("name")]
        [DbAttributeName("name")]
        public string Name { get; set; } = nameof(Model);

        [JsonPropertyName("markId")]
        [DbAttributeName("id_mark")]
        public int MarkId { get; set; } = 0;
    }
}
