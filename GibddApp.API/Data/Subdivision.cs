using GibddApp.API.Data.Base;
using System.Text.Json.Serialization;

namespace GibddApp.API.Data
{
    [DbTableName("gibdd")]
    public class Subdivision : IEntity
    {
        private int _id = 0;

        [JsonPropertyName("id")]
        [DbAttributeName("id_gibdd")]
        public int Id { get => _id; set => _id = value; }

        [DbAttributeName("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; } = nameof(Subdivision);

        [DbAttributeName("id_address")]
        [JsonPropertyName("addressId")]
        public int AddressId { get; set; } = 0;
    }
}
