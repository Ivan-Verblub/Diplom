namespace Server.MySQL.Tables.Info
{
    public class FilterInfo : FieldInfo
    {
        public string FiltType => _filtType;
        private string _filtType { get; set; }
        public FilterInfo(string dbField, string table, 
            string field, string filtType) : base(dbField, table, field)
        {
            _filtType = filtType;
        }
    }
}
