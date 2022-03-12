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
                NpgsqlConnection connection = new NpgsqlConnection(DefaultConnectionString());
                Task taskCreate = CreateAddressTableAsync(connection);
                Console.WriteLine("***********Main thread*********");
                taskCreate.Wait();

                Task taskInsert = InsertRecordsToAddressTable(5, connection);
                Console.WriteLine("Waiting for inserting data");
                taskInsert.Wait();

                Task taskUpdate = UpdateCountrysInAddressTable("Russian Federation", "Rissia", connection);
                Console.WriteLine("Waiting for updating data");
                taskUpdate.Wait();

                Task taskDelete = DeleteAddressWithCityName("Barnaul", connection);
                Console.WriteLine("Waiting for deleting data");
                taskDelete.Wait();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey(true);
            }
        }

        static void CheckConnectionAndCloseIt()
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
            string host = "192.168.1.134";
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

        static async Task CreateAddressTableAsync(NpgsqlConnection connection)
        {
            try
            {
                await connection.OpenAsync();
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    throw new Exception("Connection was not opened!");
                }
                Console.WriteLine("Connection opened");
                NpgsqlCommand command = new NpgsqlCommand();
                
                command.CommandText = "create table if not exists address (" +
                    "id serial not null CONSTRAINT firstkey PRIMARY KEY," +
                    "country_name text not null," +
                    "region_name text not null," +
                    "city_name text not null," +
                    "street_name text not null," +
                    "house_number integer" +
                    ")" +
                    "with (autovacuum_enabled=true)";
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                int result = await command.ExecuteNonQueryAsync();
                Console.WriteLine("Result: " + result);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"ExceptionType: {ex.GetType().Name}");
                Console.WriteLine($"Text: {ex.Message}");
                Console.ReadKey(true);
            }
            finally
            {
                await connection.CloseAsync();
                if (connection.FullState == System.Data.ConnectionState.Closed)
                    Console.WriteLine("Connection closed");
                else
                    Console.WriteLine("Connection is not closed. Problem.....");
            }
        }

        static async Task InsertRecordsToAddressTable(int countOfRecords, NpgsqlConnection connection)
        {
            Console.WriteLine($"{DateTime.Now}: Openinig connection...");
            await connection.OpenAsync();

            Console.WriteLine($"{DateTime.Now}: Connection: {connection.State}");
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
            int result;
            for (int i = 0; i < countOfRecords; i++)
            {
                command.CommandText = $"insert into address (country_name, region_name, city_name, street_name, house_number)" +
                $" values ('Rissia', 'Altai region', 'Barnaul', 'Lenina', '{i}')";
                result = command.ExecuteNonQuery();
                Console.WriteLine($"Result: {result}");
            }
            Console.WriteLine($"{DateTime.Now}: Closing connection...");
            await connection.CloseAsync();
            Console.WriteLine($"{DateTime.Now}: Connection: {connection.State}");
        }

        static async Task UpdateCountrysInAddressTable(string country_name, string old_name, NpgsqlConnection connection)
        {
            Console.WriteLine($"{DateTime.Now}: Openinig connection...");
            await connection.OpenAsync();

            Console.WriteLine($"{DateTime.Now}: Connection:  {connection.State}");
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
            int result;
            command.CommandText = $"update address set country_name = '{country_name}' where country_name = '{old_name}'";
            result = await command.ExecuteNonQueryAsync();
            Console.WriteLine($"Result: {result}");
            Console.WriteLine($"{DateTime.Now}: Closing connection...");
            await connection.CloseAsync();
            Console.WriteLine($"{DateTime.Now}: Connection: {connection.State}");
        }

        static async Task DeleteAddressWithCityName(string city_name, NpgsqlConnection connection)
        {
            Console.WriteLine("Deleting data");
            Console.WriteLine($"{DateTime.Now}: Openinig connection...");
            await connection.OpenAsync();

            Console.WriteLine($"{DateTime.Now}: Connection: {connection.State}");
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
            int result;
            command.CommandText = $"delete from address where city_name = '{city_name}';";
            result = await command.ExecuteNonQueryAsync();
            Console.WriteLine($"Result: {result}");
            Console.WriteLine($"{DateTime.Now}: Closing connection...");
            await connection.CloseAsync();
            Console.WriteLine($"{DateTime.Now}: Connection: {connection.State}");
        }
    }
}
