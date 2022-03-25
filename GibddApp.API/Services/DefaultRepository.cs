using GibddApp.API.Data.Base;
using GibddApp.API.Services.Base;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Text;
using System.Reflection;

namespace GibddApp.API.Services
{
    /// <summary>
    /// Репозиторий сущностей с именем Т. Т должен соответствовать названию таблицы в БД, иначе придется пилить свой репозиторий.
    /// Для обозначения имени в БД можно и нужно использовать атрибут DbTableNameAttribute из GibddApp.API.Data.Base
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DefaultRepository<T> : IRepository<T> where T : IEntity, new()
    {
        protected string _tableName;
        protected IDbContext _dbContext;
        public DefaultRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task CreateEntity(T entity, CancellationToken cancellationToken = default)
        {
            DbConnection connection = _dbContext.Connection;
            DbCommand command = _dbContext.Command;
            command.Connection = connection;
            command.CommandText = $"insert into {TableName()} ({GetPropertiesWithoutProperty(entity, nameof(entity.Id))})" +
                $" values ({GetPropertiesValuesWithoutProperty(entity, nameof(entity.Id))});";
            await connection.OpenAsync(cancellationToken);
            await command.ExecuteNonQueryAsync(cancellationToken);
            await connection.CloseAsync();
        }

        public virtual async Task DeleteById(int id, CancellationToken cancellationToken = default)
        {
            DbConnection connection = _dbContext.Connection;
            DbCommand command = _dbContext.Command;
            command.Connection = connection;
            command.CommandText = $"delete from {TableName()} where {GetDbAttributeNameOfProperty("Id")} = {id};";
            await connection.OpenAsync(cancellationToken);
            await command.ExecuteNonQueryAsync(cancellationToken);
            await connection.CloseAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken = default)
        {
            DbConnection connection = _dbContext.Connection;
            DbCommand command = _dbContext.Command;
            command.Connection = connection;
            command.CommandText = $"select * from {TableName()};";
            await connection.OpenAsync();
            DbDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
            T entity;
            List<T> entities = new List<T>();
            while (reader.Read())
            {
                entity = new T();
                await SetPropertiesValuesOf(entity, reader);
                entities.Add(entity);
            }
            await reader.CloseAsync();
            await connection.CloseAsync();
            return entities;
        }

        public virtual async Task<T> GetById(int id, CancellationToken cancellationToken = default)
        {
            DbConnection connection = _dbContext.Connection;
            DbCommand command = _dbContext.Command;
            command.Connection = connection;
            command.CommandText = $"select * from {TableName()} where {GetDbAttributeNameOfProperty("Id")} = {id};";
            connection.Open();
            //DbDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
            DbDataReader reader = command.ExecuteReader();
            T entity = new T();
            if (!reader.HasRows)
                return default(T);
            reader.Read();
            await SetPropertiesValuesOf(entity, reader);
            await reader.CloseAsync();
            await connection.CloseAsync();
            return entity;
        }

        public virtual async Task UpdateEntity(T entity, CancellationToken cancellationToken = default)
        {
            DbConnection connection = _dbContext.Connection;
            DbCommand command = _dbContext.Command;
            command.Connection = connection;
            command.CommandText = $"update {TableName()} set ({GetPropertiesWithoutProperty(entity, nameof(entity.Id))})" +
                $" = ({GetPropertiesValuesWithoutProperty(entity, nameof(entity.Id))}) " +
                $"where {GetDbAttributeNameOfProperty(nameof(entity.Id))} = {entity.Id};";
            await connection.OpenAsync(cancellationToken);
            await command.ExecuteNonQueryAsync(cancellationToken);
            await connection.CloseAsync();
        }

        protected string SetTableName()
        {
            string result = nameof(T);
            Type type = typeof(T);
            object[] attributes = type.GetCustomAttributes(false);
            foreach (Attribute item in attributes)
            {
                if (item is DbTableNameAttribute tableNameAttribute)
                {
                    result = tableNameAttribute.TableName;
                    break;
                }
            }
            return result;
        }

        protected string TableName() => _tableName ??= SetTableName();

        protected virtual string GetPropertiesOf(T entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Type type = entity.GetType();

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

        protected virtual string GetPropertiesWithoutProperty(T entity, string propertyName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Type type = entity.GetType();

            PropertyInfo[] properties = type.GetProperties();
            foreach (var item in properties)
            {
                if (item.Name != propertyName)
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
            }
            string result = stringBuilder.ToString();
            return result.Substring(0, result.Length - 2);
        }
        protected virtual string GetPropertiesValuesOf(T entity)
        {
            StringBuilder builder = new StringBuilder();

            Type type = entity.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (var property in properties)
            {
                builder.Append($"{property.GetValue(entity).ToString()}, ");
            }
            string result = builder.ToString();
            return result.Substring(0, result.Length - 2);
        }

        protected virtual string GetPropertiesValuesWithoutProperty(T entity, string propertyName)
        {
            StringBuilder builder = new StringBuilder();

            Type type = entity.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (var property in properties)
            {
                if (property.Name != propertyName)
                {
                    var attributes = property.GetCustomAttributes();
                    foreach (Attribute attribute in attributes)
                    {
                        if (attribute is DbAttributeNameAttribute)
                        {
                            if (property.PropertyType == typeof(DateTime))
                            {
                                var dateTime = (DateTime)property.GetValue(entity);
                                builder.Append($"make_date({dateTime.Year}, {dateTime.Month}, {dateTime.Day}), ");
                            }
                            else if (property.PropertyType == typeof(string))
                            {
                                builder.Append($"'{property.GetValue(entity).ToString()}', ");
                            }
                            else
                                builder.Append($"{property.GetValue(entity).ToString()}, ");
                            break;
                        }
                    }                   
                }  
            }
            string result = builder.ToString();
            return result.Substring(0, result.Length - 2);
        }

        protected virtual Task SetPropertiesValuesOf(T entity, DbDataReader dataReader)
        {
            return Task.Factory.StartNew(() =>
            {
                Type type = entity.GetType();
                PropertyInfo[] properties = type.GetProperties();
                for (int i = 0; i < properties.Length; i++)
                {
                    object[] attributes = properties[i].GetCustomAttributes(false);
                    foreach (Attribute attribute in attributes)
                    {
                        if (attribute is DbAttributeNameAttribute nameAttribute)
                        {
                            properties[i].SetValue(entity, dataReader[nameAttribute.AttributeName]);
                            break;
                        }
                    }                   
                }
            });
        }

        protected virtual string GetDbAttributeNameOfProperty(string propertyName)
        {
            Type type = typeof(T);
            string result = propertyName;
            PropertyInfo[] properties = type.GetProperties();
            object[] attributes;
            foreach (var property in properties)
            {
                if (property.Name == propertyName)
                {
                    attributes = property.GetCustomAttributes(false);
                    foreach (var attribute in attributes)
                    {
                        if (attribute is DbAttributeNameAttribute nameAttribute)
                        {
                            result = nameAttribute.AttributeName;
                            break;
                        }
                    }
                    break;
                }                
            }
            return result;
        }
    }
}
