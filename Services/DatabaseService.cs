using MySql.Data.MySqlClient;
using System.Data;

namespace DispatchManager.Services
{

    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable ExecuteQuery(string query)
        {
            using var connection = new MySqlConnection(_connectionString);
            using var command = new MySqlCommand(query, connection);
            using var adapter = new MySqlDataAdapter(command);
            var table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public int ExecuteNonQuery(string query)
        {
            using var connection = new MySqlConnection(_connectionString);
            using var command = new MySqlCommand(query, connection);
            connection.Open();
            return command.ExecuteNonQuery();
        }
    }
}
