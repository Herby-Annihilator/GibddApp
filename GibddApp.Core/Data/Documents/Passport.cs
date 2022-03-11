using GibddApp.Core.Data.RoadAccidentParticipants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.Core.Data.Documents
{
    public class Passport : Document
    {
        public string SubdivisionCode { get; set; }
        public DateTime CreationDate { get; set; }

        public string MvdSubdivisioName { get; set; }

        public Passport(int id, string serial, string number, Citizen owner, 
            string subdivisionCode, DateTime creationDate, string mvdSubdivisioName) : base(id, serial, number, owner)
        {
            SubdivisionCode = subdivisionCode;
            CreationDate = creationDate;
            MvdSubdivisioName = mvdSubdivisioName;
        }
    }
}
