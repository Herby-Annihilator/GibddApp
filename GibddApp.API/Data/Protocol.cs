using GibddApp.API.Data.Base;
using System;
using System.Text.Json.Serialization;

namespace GibddApp.API.Data
{
    [DbTableName("protocol")]
    public class Protocol : IEntity
    {
        protected int _id = 0;

        [DbAttributeName("id_protocol")]
        [JsonPropertyName("id")]
        public int Id { get => _id; set => _id = value; }

        [DbAttributeName("date")]
        [JsonPropertyName("creationDate")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [JsonPropertyName("roadAccidentAddressId")]
        [DbAttributeName("id_accident_address")]
        public int RoadAccidentAddressId { get; set; } = 0;

        [JsonPropertyName("creationPalceAddressId")]
        [DbAttributeName("id_compile_address")]
        public int CreationPalceAddressId { get; set; } = 0;
    }
}
