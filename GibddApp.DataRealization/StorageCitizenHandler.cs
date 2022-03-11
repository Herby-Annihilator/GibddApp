using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GibddApp.Core.Data.RoadAccidentParticipants;
using GibddApp.Core.Services;
using Npgsql;

namespace GibddApp.DataRealization
{
    public class StorageCitizenHandler : IStorageEntityHandler<Citizen>
    {
        private NpgsqlConnection _connection;
        public StorageCitizenHandler(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
        }
        public Task DeleteEntity(Citizen entity)
        {
            throw new NotImplementedException();
        }

        public Task<Citizen> GetEntity(Func<string> query)
        {
            throw new NotImplementedException();
        }

        public Task SaveEntity(Citizen entity)
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            NpgsqlCommand command = new NpgsqlCommand();
            _connection.Close();

            throw new NotImplementedException();
        }

        public Task UpdateEntity(Citizen oldEntity, Citizen newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
