namespace Server.MySQL.Atributes.Filter
{
    [System.AttributeUsage(AttributeTargets.Field 
        | AttributeTargets.Property | AttributeTargets.Property
        , AllowMultiple = true)]
    public class FilterAtribute: Attribute, IDisposable
    {
        public string Field;
        public string Table;
        public FType FiltType;
        

        public FilterAtribute(string field,string table,FType filtType)
        {
            Field = field;
            Table = table;
            FiltType = filtType;
        }

        public void Dispose()
        {

        }
    }
}
