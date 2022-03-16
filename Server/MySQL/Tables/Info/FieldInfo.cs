namespace Server.MySQL.Tables
{
    public class FieldInfo
    {
        public string DBField => _dbField;
        private string _dbField { get; set; }
        public string Table => _table;
        private string _table { get; set; }
        public string Field => _field;
        private string _field { get; set; }
        public FieldInfo(string dbField, string table,string field)
        {
            _dbField = dbField; 
            _table = table;
            _field = field;
        }
    }
}
