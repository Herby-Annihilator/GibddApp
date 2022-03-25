using System.Text.Json.Serialization;

namespace GibddApp.API.Data
{
    public class SuperProtocolAppendix : ProtocolAppendix
    {
        [JsonPropertyName("vehicle")]
        public CustomVehicle Vehicle { get; set; }

        public static SuperProtocolAppendix FromProtocolAppendix(ProtocolAppendix protocolAppendix)
        {
            return new SuperProtocolAppendix()
            {
                DamageDescription = protocolAppendix.DamageDescription,
                Id = protocolAppendix.Id,
                ProtocolId = protocolAppendix.ProtocolId,
                VehicleId = protocolAppendix.VehicleId,
            };
        }
    }
}
