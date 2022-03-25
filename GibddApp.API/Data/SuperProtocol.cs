using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GibddApp.API.Data
{
    public class SuperProtocol : Protocol
    {
        [JsonPropertyName("roadAccidentAddress")]
        public Address RoadAccidentAddress { get; set; }

        [JsonPropertyName("creationPalceAddress")]
        public Address CreationPalceAddress { get; set; }

        [JsonPropertyName("creator")]
        public Employee Creator { get; set; }

        [JsonPropertyName("participants")]
        public IEnumerable<SuperParticipant> Participants { get; set; }

        [JsonPropertyName("protocolAppendices")]
        public IEnumerable<SuperProtocolAppendix> ProtocolAppendices { get; set; }

        //[JsonPropertyName("culprits")]
        //public IEnumerable<Participant> Сulprits { get; set; } // виновники

        //[JsonPropertyName("accidentVictims")]
        //public IEnumerable<Participant> AccidentVictims { get; set; } // пострадавшие

        public static SuperProtocol FromProtocol(Protocol protocol)
        {
            return new SuperProtocol()
            {
                CreationDate = protocol.CreationDate,
                CreationPalceAddressId = protocol.CreationPalceAddressId,
                Id = protocol.Id,
                RoadAccidentAddressId = protocol.RoadAccidentAddressId,
            };
        }

        public Protocol GetProtocol()
        {
            return new Protocol
            {
                CreationDate = this.CreationDate,
                CreationPalceAddressId = this.CreationPalceAddressId,
                Id = this.Id,
                RoadAccidentAddressId = this.RoadAccidentAddressId,
            };
        }
    }
}
