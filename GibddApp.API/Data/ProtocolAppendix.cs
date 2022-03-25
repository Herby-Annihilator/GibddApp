using GibddApp.API.Data.Base;
using System.Text.Json.Serialization;

namespace GibddApp.API.Data
{
    [DbTableName("protocol_app")]
    public class ProtocolAppendix : IEntity
    {
        protected int _id = 0;

        [DbAttributeName("id_protocol_app")]
        [JsonPropertyName("id")]
        public int Id { get => _id; set => _id = value; }


        [JsonPropertyName("damageDescription")]
        [DbAttributeName("damage")]
        public string DamageDescription { get; set; } = "";


        [JsonPropertyName("protocolId")]
        [DbAttributeName("id_protocol")]
        public int ProtocolId { get; set; } = 0;

        [JsonPropertyName("vehicleId")]
        [DbAttributeName("id_vehicle")]
        public int VehicleId { get; set; } = 0;
    }
}
