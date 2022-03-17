using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.DataRealization
{
    public class PgSqlDbContext : IDbContext
    {
        public string ConnectionString => "Host=192.168.1.123;Port=5432;Database=postgres;Username=postgres;Password=qwerty;";
    }
}
