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
            _connectionString = $"Data Source = {host};Database = gos;" +
                $"User = {user};password = {pass};charset = utf8";
            _connection = new MySqlConnection(_connectionString);
        }
        public void Dispose()
        {
            _connection.Dispose();
        }
        public bool Open()
        {
            try
            {
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
