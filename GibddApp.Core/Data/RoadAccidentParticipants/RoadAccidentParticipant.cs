using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.Core.Data.RoadAccidentParticipants
{
    public class RoadAccidentParticipant : Citizen
    {
        public RoadAccidentParticipantRole Role { get; set; }
        public RoadAccidentParticipant(string firstName, string lastName, Sex sex, RoadAccidentParticipantRole role) :
            base(firstName, lastName, sex)
        {
            Role = role;
        }
    }
}
