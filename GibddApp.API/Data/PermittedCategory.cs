using GibddApp.API.Data.Base;
using System;
using System.Text.Json.Serialization;

namespace GibddApp.API.Data
{
    [DbTableName("permit_category")]
    public class PermittedCategory : IEntity
    {
        private int _id = 0;

        [DbAttributeName("id_permit_category")]
        [JsonPropertyName("id")]
        public int Id { get => _id; set => _id = value; }

        [JsonPropertyName("startDate")]
        [DbAttributeName("start_date")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [JsonPropertyName("endDate")]
        [DbAttributeName("end_date")]
        public DateTime EndDate { get; set; } = DateTime.Now;

        [JsonPropertyName("categoryId")]
        [DbAttributeName("id_category")]
        public int CategoryId { get; set; } = 0;

        [JsonPropertyName("driverLicenseId")]
        [DbAttributeName("id_driver_license")]
        public int DriverLicenseId { get; set; } = 0;
    }
}
