using GibddApp.API.Data.Base;
using System;
using System.Text.Json.Serialization;

namespace GibddApp.API.Data
{
    [DbTableName("vehicle")]
    public class Vehicle : IEntity
    {
        protected int _id;

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
        [JsonPropertyName("registrationDate")]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        [DbAttributeName("id_model")]
        [JsonPropertyName("modelId")]
        public int ModelId { get; set; } = 0;

        [DbAttributeName("id_mark")]
        [JsonPropertyName("markId")]
        public int MarkId { get; set; } = 0;

        [DbAttributeName("id_color")]
        [JsonPropertyName("colorId")]
        public int ColorId { get; set; } = 0;

        [DbAttributeName("id_category")]
        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; } = 0;

        public bool EqualNotById(Vehicle vehicle)
        {
            if (vehicle == null)
                return false;
            if (ReferenceEquals(vehicle, this))
                return true;
            if (Weight == vehicle.Weight
                && MaxWeight == vehicle.MaxWeight
                && CreationDate == vehicle.CreationDate
                && ChassisNumber == vehicle.ChassisNumber
                && BodyNumber == vehicle.BodyNumber
                && VIN == vehicle.VIN
                && RegistrationDate == vehicle.RegistrationDate
                && ModelId == vehicle.ModelId
                && MarkId == vehicle.MarkId
                && ColorId == vehicle.ColorId
                && CategoryId == vehicle.CategoryId)
                return true;
            return false;

        }
    }
}
