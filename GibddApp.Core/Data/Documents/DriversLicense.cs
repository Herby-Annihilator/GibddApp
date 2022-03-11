using GibddApp.Core.Data.Common;
using GibddApp.Core.Data.RoadAccidentParticipants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.Core.Data.Documents
{
    public class DriversLicense : Document
    {
        public List<AllowedCategory> AllowedCategories { get; set; }
        public DriversLicense(int id, string serial, string number, Citizen owner, List<AllowedCategory> allowedCategories) :
            base(id, serial, number, owner)
        {
            AllowedCategories = allowedCategories;
        }
    }
}
