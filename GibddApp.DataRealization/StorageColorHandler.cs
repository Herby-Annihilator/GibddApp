using GibddApp.Core.Data.Common;
using GibddApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace GibddApp.DataRealization
{
    public class StorageColorHandler : IStorageEntityHandler<Color>
    {
        private IDbContext _dbContext;
        public StorageColorHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task DeleteEntity(Color entity)
        {
            NpgsqlConnection connection = new NpgsqlConnection(_dbContext.ConnectionString);
            try
            { 
                await connection.OpenAsync();
                string query = $"delete from color where id_color = {entity.Id};";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                await command.ExecuteNonQueryAsync();
                await connection.CloseAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                    await connection.CloseAsync();
            }
        }

        public async Task<Color> GetEntity(Func<string> query)
        {
            NpgsqlConnection connection = new NpgsqlConnection(_dbContext.ConnectionString);
            try
            {

                await connection.OpenAsync();
                NpgsqlCommand command = new NpgsqlCommand(query(), connection);
                var reader = await command.ExecuteReaderAsync();
                reader.Read();
                Color color = new Color((string)reader["name"], (int)reader["id_color"]);
                await connection.CloseAsync();
                return color;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                    await connection.CloseAsync();
            }
        }

        public async Task SaveEntity(Color entity)
        {
            NpgsqlConnection connection = new NpgsqlConnection(_dbContext.ConnectionString);
            try
            {
                await connection.OpenAsync();
                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = connection; ;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "add_color";

                command.Parameters.AddWithValue("_name", entity.Name);
                await command.ExecuteNonQueryAsync();
                await connection.CloseAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                    await connection.CloseAsync();
            }
        }

        public async Task UpdateEntity(Color oldEntity, Color newEntity)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_dbContext.ConnectionString))
            {
                await connection.OpenAsync();
                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = connection;
                command.CommandText = $"update color set name = '{newEntity.Name}' where name = '{oldEntity.Name}';";
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
