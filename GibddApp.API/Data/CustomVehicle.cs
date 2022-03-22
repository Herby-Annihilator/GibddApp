using System.Text.Json.Serialization;

namespace GibddApp.API.Data
{
    public class CustomVehicle : Vehicle
    {
        [JsonPropertyName("markName")]
        public string MarkName { get; set; } = "mark";

        [JsonPropertyName("modelName")]
        public string ModelName { get; set; } = "model";

        [JsonPropertyName("colorName")]
        public string ColorName { get; set; } = "color";

        [JsonPropertyName("categoryName")]
        public string CategoryName { get; set; } = "category";

        public static CustomVehicle FromVehicle(Vehicle vehicle)
        {
            CustomVehicle custom = new CustomVehicle()
            {
                CategoryId = vehicle.CategoryId,
                BodyNumber = vehicle.BodyNumber,
                ChassisNumber = vehicle.ChassisNumber,
                ColorId = vehicle.ColorId,
                CreationDate = vehicle.CreationDate,
                Id = vehicle.Id,
                MarkId = vehicle.MarkId,
                MaxWeight = vehicle.MaxWeight,
                ModelId = vehicle.ModelId,
                RegistrationDate = vehicle.RegistrationDate,
                VIN = vehicle.VIN,
                Weight = vehicle.Weight,
                CategoryName = "categoryName",
                MarkName = "markName",
                ModelName = "modelName",
                ColorName = "colorName",
            };
            return custom;
        }
    }
}
