using MySql.Data.MySqlClient;
using Server.MySQL.Tables;

namespace Server.MySQL
{
    public class Connector : IDisposable
    { 
        private string _connectionString;
        public MySqlConnection Connection => _connection;
        private MySqlConnection _connection;
        public Connector(string host, string user, string pass)
        {
            _connectionString = $"Data Source = {host};" +
                $"User = {user};password = {pass};charset = utf8";
            _connection = new MySqlConnection(_connectionString);
        }
        public void Dispose()
        {
            _connection.Dispose();
        }

        public bool TryOpen()
        {
            try
            {
                _connection.ConnectionString = _connectionString;
                _connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Open()
        {
            try
            {
                _connection.ConnectionString = _connectionString;
                _connection.ConnectionString += ";Database = gos;";
                _connection.Open();
                return true; 
            }
            catch(MySqlException)
            {
                return false;
            }
        }

        public void Close()
        {
            try
            {
                _connection.Close();
            }
            catch { }
        }
        
    }

}
