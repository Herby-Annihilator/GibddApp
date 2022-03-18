using GibddApp.API.Data.Base;
using System.Data.Common;
using System.Threading.Tasks;
using System.Reflection;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GibddApp.API.Data
{
    [DbTableName("color")]
    public class Color : IEntity
    {
        [JsonPropertyName("name")]
        [DbAttributeName("name")]
        public string Name { get; set; }
        protected int _id;
        [JsonPropertyName("id")]
        [DbAttributeName("id_color")]
        public int Id { get => _id; set => _id = value; }

        public Color()
        {
            Id = 0;
            Name = nameof(Color);
        }
    }
}
