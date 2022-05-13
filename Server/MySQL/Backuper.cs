using MySql.Data.MySqlClient;

namespace Server.MySQL
{
    public class Backuper
    {
        static private Backuper _instance = null;
        private MySqlCommand _cmd;
        private MySqlBackup _backup;
        private Backuper(Connector connector)
        {
            _cmd = new MySqlCommand();
            _cmd.Connection = connector.Connection;
            _backup = new MySqlBackup(_cmd);
        }
        public static Backuper GetInstance()
        {
            if (_instance == null)
                throw new NullReferenceException();
            return _instance;
        }
        public static Backuper GetInstance(Connector connector)
        {
            if(_instance == null)
                _instance = new Backuper(connector);
            return _instance;
        }

        public string Export()
        {
            return _backup.ExportToString();
        }

        public void Import(string text)
        {
            _backup.ImportFromString(text);
        }
    }
}
