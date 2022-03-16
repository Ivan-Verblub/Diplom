namespace Server.MySQL.Atributes
{
    [System.AttributeUsage(System.AttributeTargets.Parameter |
        AttributeTargets.Field | AttributeTargets.Property
        , AllowMultiple = true)]
    public class DBAtribute: System.Attribute, IDisposable
    {
        public bool Hide;
        public string Table;
        public string Field;

        public DBAtribute(bool hide,string table, string field)
        {
            Hide = hide;
            Table = table;
            Field = field;
        }

        public void Dispose()
        {
        }
    }
}
