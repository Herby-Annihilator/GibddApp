using System;

namespace GibddApp.API.Data.Base
{
    public class DbTableNameAttribute : Attribute
    {
        public string TableName { get; set; }
        public DbTableNameAttribute(string tableName)
        {
            TableName = tableName;
        }
    }
}
