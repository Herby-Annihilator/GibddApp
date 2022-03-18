using GibddApp.API.Data.Base;
using System.Data.Common;
using System.Threading.Tasks;
using System.Reflection;
using System;
using System.Text;

namespace GibddApp.API.Data
{
    [DbTableName("color")]
    public class Color : Entity
    {
        [DbAttributeName("name")]
        public string Name { get; set; }
        public override string GetProperties()
        {
            StringBuilder stringBuilder = new StringBuilder();
            Type type = typeof(Color);

            PropertyInfo[] properties = type.GetProperties();
            foreach (var item in properties)
            {
                var attributes = item.GetCustomAttributes();
                foreach (Attribute attribute in attributes)
                {
                    if (attribute is DbAttributeNameAttribute dbAttributeNameAttribute)
                    {
                        stringBuilder.Append($"{dbAttributeNameAttribute.AttributeName}, ");
                        break;
                    }
                }
            }
            string result = stringBuilder.ToString();
            return result.Substring(0, result.Length - 2);
        }

        public override string GetPropertiesValues()
        {
            StringBuilder builder = new StringBuilder();

            Type type = typeof(Color);
            PropertyInfo[] properties = type.GetProperties();
            foreach (var property in properties)
            {
                builder.Append($"{property.GetValue(this).ToString()}, ");
            }
            string result = builder.ToString();
            return result.Substring(0, result.Length - 2);
        }

        public override Task SetPropertiesValues(DbDataReader dataReader)
        {
            return Task.Factory.StartNew(() => 
            {
                Type type = typeof(Color);
                PropertyInfo[] properties = type.GetProperties();
                for (int i = 0; i < properties.Length; i++)
                {
                    properties[i].SetValue(this, dataReader.GetValue(i));
                }
            });
        }
    }
}
