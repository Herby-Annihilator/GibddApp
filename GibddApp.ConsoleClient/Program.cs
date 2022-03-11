using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace GibddApp.ConsoleClient
{
    public static class Program
    {
       
        public static void Main(string[] args)
        {
            try
            {                 
                ConnectToPostgres();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey(true);
            }
        }

        static void ConnectToPostgres()
        {
            Console.WriteLine("Connecting to PostgreSQL Pro...");
            NpgsqlConnection connection = new NpgsqlConnection(DefaultConnectionString());
            connection.Open();
            Console.WriteLine(connection.FullState.ToString());
            Console.ReadKey(true);
            connection.Close();
            Console.WriteLine(connection.FullState.ToString());
        }

        static string DefaultConnectionString()
        {
            string host = "192.168.1.123";
            string database = "postgres";
            string user = "postgres";
            string password = "qwerty";
            int port = 5432;

            Console.WriteLine("\r\n\\\\---------------------------------//");
            Console.WriteLine($"Host: {host}");
            Console.WriteLine($"User: {user}");
            Console.WriteLine($"Password: {password}");
            Console.WriteLine($"Database: {database}");
            Console.WriteLine($"Port: {port}");
            Console.WriteLine("//---------------------------------\\\\\r\n\\");
            return ConnectionString(host, user, password, database, port);
        }

        static string ConnectionString(string host, string user, string password, string database, int port) =>
            $"Host={host};Port={port};Database={database};Username={user};Password={password};";
    }
}
