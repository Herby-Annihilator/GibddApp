using GibddApp.API.Data.Base;
using System;
using System.Text.Json.Serialization;

namespace GibddApp.API.Data
{
    [DbTableName("vehicle")]
    public class Vehicle : IEntity
    {
        private int _id;

        [DbAttributeName("id_vehicle")]
        [JsonPropertyName("id")]
        public int Id { get => _id; set => _id = value; }

        [DbAttributeName("weight")]
        [JsonPropertyName("weight")]
        public int Weight { get; set; } = 0;

        [DbAttributeName("max_weight")]
        [JsonPropertyName("maxWeight")]
        public int MaxWeight { get; set; } = 0;

        [DbAttributeName("year")]
        [JsonPropertyName("creationDate")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [DbAttributeName("chassis_number")]
        [JsonPropertyName("chassisNumber")]
        public string ChassisNumber { get; set; } = nameof(ChassisNumber);  // номер шасси

        [DbAttributeName("body_number")]
        [JsonPropertyName("bodyNumber")]
        public string BodyNumber { get; set; } = nameof(BodyNumber);  // номер кузова

        [DbAttributeName("vin")]
        [JsonPropertyName("vin")]
        public string VIN { get; set; } = nameof(VIN);

        [DbAttributeName("date_delivery")]
        [JsonPropertyName("registratioDate")]
        public DateTime RegistratioDate { get; set; } = DateTime.Now;

        [DbAttributeName("id_model")]
        [JsonPropertyName("modelId")]
        public int ModelId { get; set; } = 0;

        [DbAttributeName("id_mark")]
        [JsonPropertyName("markId")]
        public int MarklId { get; set; } = 0;

        [DbAttributeName("id_color")]
        [JsonPropertyName("colorlId")]
        public int ColorlId { get; set; } = 0;

        [DbAttributeName("id_category")]
        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; } = 0;
    }
}
