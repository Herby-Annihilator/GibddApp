using GibddApp.API.Data.Base;
using System.Text.Json.Serialization;

namespace GibddApp.API.Data
{
    [DbTableName("mark")]
    public class Mark : IEntity
    {
        private int _id;

        [JsonPropertyName("id")]
        [DbAttributeName("id_mark")]
        public int Id { get => _id; set => _id = value; }

        [JsonPropertyName("name")]
        [DbAttributeName("name")]
        public string Name { get; set; }
    }
}
