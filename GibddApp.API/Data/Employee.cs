using GibddApp.API.Data.Base;
using System.Text.Json.Serialization;

namespace GibddApp.API.Data
{
    [DbTableName("worker")]
    public class Employee : IEntity
    {
        private int _id;

        [JsonPropertyName("id")]
        [DbAttributeName("id_worker")]
        public int Id { get => _id; set => _id = value; }

        [JsonPropertyName("firstName")]
        [DbAttributeName("family")]
        public string FirstName { get; set; } = nameof(FirstName);

        [JsonPropertyName("lastName")]
        [DbAttributeName("name")]
        public string LastName { get; set; } = nameof(LastName);

        [JsonPropertyName("patronymic")]
        [DbAttributeName("Patronymic")]
        public string Patronymic { get; set; } = "";

        [JsonPropertyName("subdivisionId")]
        [DbAttributeName("id_gibdd")]
        public int SubdivisionId { get; set; } = 0;

        [JsonPropertyName("rankId")]
        [DbAttributeName("id_rank")]
        public int RankId { get; set; } = 0;

        [JsonPropertyName("positionId")]
        [DbAttributeName("id_position")]
        public int PositionId { get; set; } = 0;

        public bool EqualNotById(Employee employee)
        {
            if (employee == null)
                return false;
            if (ReferenceEquals(employee, this))
                return true;
            if (FirstName == employee.FirstName
                && LastName == employee.LastName
                && Patronymic == employee.Patronymic
                && SubdivisionId == employee.SubdivisionId
                && RankId == employee.RankId
                && PositionId == employee.PositionId)
                return true;
            return false;
        }
    }
}
