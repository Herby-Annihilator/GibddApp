using GibddApp.Core.Data.Base;
using GibddApp.Core.Data.RoadAccidentParticipants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.Core.Data
{
    public class Protocol : IEntity
    {
        private int _id;
        public int Id { get => _id; set => _id = value; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public Address PlaceOfRecord { get; set; } = Address.Invalid();
        public Address PlaceOfTrafficAccident { get; set; } = Address.Invalid();

        public List<IMediafile> Mediafiles { get; set; } = new List<IMediafile>();

        public List<ProtocolAddition> Additions { get; set; } = new List<ProtocolAddition>();

        /// <summary>
        /// Нарушитель
        /// </summary>
        public Citizen Intruder { get; set; }

        /// <summary>
        /// Пострадавшие
        /// </summary>
        public List<Citizen> Victims { get; set; }

        /// <summary>
        /// Свидетели
        /// </summary>
        public List<Citizen> Witnesses { get; set; }
    }
}
