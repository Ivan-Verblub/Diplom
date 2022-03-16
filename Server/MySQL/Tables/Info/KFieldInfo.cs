namespace Server.MySQL.Tables
{
    public class KFieldInfo : FieldInfo
    {
        public bool AI => _ai;
        private bool _ai { get; set; }
        public KFieldInfo(string dbField, string table,
            string field, bool ai) 
            : base(dbField, table, field)
        {
            _ai = ai;
        }
    }
}
