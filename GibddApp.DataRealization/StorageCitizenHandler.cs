using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GibddApp.Core.Data.RoadAccidentParticipants;
using GibddApp.Core.Services;
using Npgsql;
using NpgsqlTypes;
using GibddApp.Core.Data;

namespace GibddApp.DataRealization
{
    public class StorageCitizenHandler : IStorageEntityHandler<Citizen>
    {
        private IDbContext _dbContext;
        public StorageCitizenHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task DeleteEntity(Citizen entity)
        {
            throw new NotImplementedException();
        }

        public Task<Citizen> GetEntity(Func<string> query)
        {
            throw new NotImplementedException();
        }

        public async Task SaveEntity(Citizen entity)
        {
            NpgsqlConnection connection = new NpgsqlConnection(_dbContext.ConnectionString);
            try
            {
                await connection.OpenAsync();
                NpgsqlCommand command = new NpgsqlCommand("add_person", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("_family", entity.FirstName);
                command.Parameters.AddWithValue("_name", entity.LastName);
                command.Parameters.AddWithValue("_patronymic", entity.Patronymic);
                command.Parameters.AddWithValue("_job_place", entity.WorkPlaceName);
                command.Parameters.AddWithValue("_position", entity.JobTitle);
                command.Parameters.AddWithValue("_phone", entity.PhoneNumber);
                string sexName;
                if (entity.Sex == Sex.Male)
                {
                    sexName = "мужской";
                }
                else
                {
                    sexName = "женский";
                }
                int id = await GetSexIdByName(connection, sexName);
                command.Parameters.AddWithValue("_id_sex", id);
                id = await GetAddressId(connection, entity.RegistrationAddress);
                command.Parameters.AddWithValue("_id_reg_addr", id);
                id = await GetAddressId(connection, entity.ResidentialAddress);
                command.Parameters.AddWithValue("_id_living_addr", id);
                id = await GetAddressId(connection, entity.WorkPlaceAddress);
                command.Parameters.AddWithValue("_id_job_addr", id);

                await command.ExecuteNonQueryAsync();
                await connection.CloseAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    await connection.CloseAsync();
            }
        }

        public async Task<int> GetSexIdByName(NpgsqlConnection connection, string sexName)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = connection;
            command.CommandText = $"select id_sex from sex where type = '{sexName}';";
            NpgsqlDataReader reader = await command.ExecuteReaderAsync();
            int id = 0;
            while (reader.Read())
            {
                id = reader.GetInt32("id_sex");
            }
            reader.Close();
            return id;
        }

        public async Task<int> GetAddressId(NpgsqlConnection connection, Address address)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = connection;
            command.CommandText = $"select id_address from address where country = '{address.CountyName}' and district = '{address.RegionName}' and " +
                $"location = '{address.CityName}' and street = '{address.StreetName}' and home_number = '{address.HomeNumber}';";
            NpgsqlDataReader reader = await command.ExecuteReaderAsync();
            int id = 0;
            reader.Read();
            id = reader.GetInt32("id_address");
            reader.Close();
            return id;
        }
       

        public Task UpdateEntity(Citizen oldEntity, Citizen newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
