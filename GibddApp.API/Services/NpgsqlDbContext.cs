using GibddApp.API.Services.Base;
using Microsoft.Extensions.Configuration;
using System.Data.Common;

namespace GibddApp.API.Services
{
    public class NpgsqlDbContext : IDbContext
    {
        private string _connectionString;
        public NpgsqlDbContext(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionString"];
        }
        public DbCommand Command => new Npgsql.NpgsqlCommand();

        public DbConnection Connection => new Npgsql.NpgsqlConnection(_connectionString);

        public string GetConnectionStriing() => _connectionString;
    }
}
