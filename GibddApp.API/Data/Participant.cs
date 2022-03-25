using GibddApp.API.Data.Base;
using System.Text.Json.Serialization;

namespace GibddApp.API.Data
{
    [DbTableName("participant")]
    public class Participant : IEntity
    {
        protected int _id = 0;

        [JsonPropertyName("id")]
        [DbAttributeName("id_participant")]
        public int Id { get => _id; set => _id = value; }

        [JsonPropertyName("testimony")]
        [DbAttributeName("statement")]
        public string Testimony { get; set; } = "";  // показания

        [JsonPropertyName("protocolId")]
        [DbAttributeName("id_protocol")]
        public int ProtocolId { get; set; } = 0;

        [JsonPropertyName("citizenId")]
        [DbAttributeName("id_person")]
        public int CitizenId { get; set; } = 0;

        [JsonPropertyName("roleInRoadAccidentId")]
        [DbAttributeName("id_role_accident")]
        public int RoleInRoadAccidentId { get; set; } = 0;
    }
}
