using GibddApp.API.Data.Base;
using System;
using System.Text.Json.Serialization;

namespace GibddApp.API.Data
{
    [DbTableName("driver_license")]
    public class DriverLicense : IEntity
    {
        private int _id = 0;

        [DbAttributeName("id_driver_license")]
        [JsonPropertyName("id")]
        public int Id { get => _id; set => _id = value; }

        [JsonPropertyName("series")]
        [DbAttributeName("serie")]
        public string Series { get; set; } = "0113";

        [JsonPropertyName("number")]
        [DbAttributeName("number")]
        public string Number { get; set; } = "975478";

        [JsonPropertyName("startDate")]
        [DbAttributeName("start_date")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [JsonPropertyName("endDate")]
        [DbAttributeName("end_date")]
        public DateTime EndDate { get; set; } = DateTime.Now;

        [JsonPropertyName("isValid")]
        [DbAttributeName("is_valid")]
        public bool IsValid { get; set; } = true;

        [JsonPropertyName("ownerId")]
        [DbAttributeName("id_person")]
        public int OwnerId { get; set; } = 0;

    }
}
