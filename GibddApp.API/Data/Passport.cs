using GibddApp.API.Data.Base;
using System;
using System.Text.Json.Serialization;

namespace GibddApp.API.Data
{
    [DbTableName("passport")]
    public class Passport : IEntity
    {
        private int _id;

        [DbAttributeName("id_passport")]
        [JsonPropertyName("id")]
        public int Id { get => _id; set => _id = value; }

        [JsonPropertyName("series")]
        [DbAttributeName("serie")]
        public string Series { get; set; } = "0113";

        [JsonPropertyName("number")]
        [DbAttributeName("number")]
        public string Number { get; set; } = "975478";

        [JsonPropertyName("issueDate")]
        [DbAttributeName("issued_date")]
        public DateTime IssueDate { get; set; } = DateTime.Now;

        [JsonPropertyName("issuedBy")]
        [DbAttributeName("issued_by")]
        public string IssuedBy { get; set; } = "ОМВД Борвиха Северное";

        [JsonPropertyName("isValid")]
        [DbAttributeName("is_valid")]
        public bool IsValid { get; set; } = true;

        [JsonPropertyName("ownerId")]
        [DbAttributeName("id_person")]
        public int OwnerId { get; set; } = 0;
    }
}
