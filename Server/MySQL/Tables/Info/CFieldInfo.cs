namespace Server.MySQL.Tables
{
    public class CFieldInfo : FieldInfo
    {
        public CType ConType => _conType;
        private CType _conType { get; set; }
        public string CTable => _cTable;
        private string _cTable { get; set; }
        public CFieldInfo(string dbField, string table, string field,
            CType conType, string cTable) 
            : base(dbField, table, field)
        {
            _conType = conType;
            _cTable = cTable;
        }
    }
}
