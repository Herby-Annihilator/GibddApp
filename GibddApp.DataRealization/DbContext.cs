using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.DataRealization
{
    public class DbContext
    {
        public string Host { get; set; } = "localhost";

        public string DataBaseName { get; set; } = "postgres";
        public int Port { get; set; } = 5432;

        public string User { get; set; } = "postgres";

        public string Password { get; set; } 

        public DbContext(string password, string host = "localhost", string database = "postgres", int port = 5432, string user = "postgres")
        {
            Host = host;
            Password = password;
            DataBaseName = database;
            Port = port;
            User = user;
        }

        public string ConnectionString => $"Host={Host};Username={User};Password={Password};Database={DataBaseName}";
    }
}
