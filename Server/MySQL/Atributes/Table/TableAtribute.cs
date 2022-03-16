namespace Server.MySQL.Atributes
{
    [System.AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TableAtribute: Attribute, IDisposable
    {
        public string[] Tables;

        public TableAtribute(string[] tables)
        {
            Tables = tables;
        }

        public void Dispose()
        {
        }
    }
}
