using GibddApp.API.Data.Base;
using GibddApp.API.Services.Base;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using System;

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
            command.CommandText = $"insert into {TableName()} ({entity.GetProperties()}) values ({entity.GetPropertiesValues()});";
            await connection.OpenAsync(cancellationToken);
            await command.ExecuteNonQueryAsync(cancellationToken);
            await connection.CloseAsync();
        }

        public virtual async Task DeleteById(int id, CancellationToken cancellationToken = default)
        {
            DbConnection connection = _dbContext.Connection;
            DbCommand command = _dbContext.Command;
            command.Connection = connection;
            command.CommandText = $"delete from {TableName()} where id = {id};";
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
            DbDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
            T entity;
            List<T> entities = new List<T>();
            while (reader.Read())
            {
                entity = new T();
                await entity.SetPropertiesValues(reader);
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
            command.CommandText = $"select * from {TableName()} where id = {id};";
            DbDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
            T entity = new T();
            reader.Read();
            await entity.SetPropertiesValues(reader);
            await reader.CloseAsync();
            await connection.CloseAsync();
            return entity;
        }

        public virtual async Task UpdateEntity(T entity, CancellationToken cancellationToken = default)
        {
            DbConnection connection = _dbContext.Connection;
            DbCommand command = _dbContext.Command;
            command.Connection = connection;
            command.CommandText = $"update {TableName()} set ({entity.GetProperties()}) = ({entity.GetPropertiesValues()});";
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
    }
}
