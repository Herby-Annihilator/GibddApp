using System.Text.Json.Serialization;

namespace GibddApp.API.Data
{
    public class SuperParticipant : Participant
    {
        [JsonPropertyName("superUser")]
        public SuperUser SuperUser { get; set; }

        [JsonPropertyName("roleInRoadAccident")]
        public RoleInRoadAccident Role { get; set; }

        public static SuperParticipant FromParticipant(Participant participant)
        {
            return new SuperParticipant()
            {
                CitizenId = participant.CitizenId,
                Id = participant.Id,
                ProtocolId = participant.ProtocolId,
                RoleInRoadAccidentId = participant.RoleInRoadAccidentId,
                Testimony = participant.Testimony,
            };
        }
    }
}
