using GibddApp.API.Data.Base;
using System.Text.Json.Serialization;

namespace GibddApp.API.Data
{
    [DbTableName("rank")]
    public class Rank : IEntity
    {
        private int _id = 0;

        [JsonPropertyName("id")]
        [DbAttributeName("id_rank")]
        public int Id { get => _id; set => _id = value; }


        [JsonPropertyName("name")]
        [DbAttributeName("name")]
        public string Name { get; set; } = nameof(Name);
    }
}
