namespace Server.MySQL.Atributes
{
    [System.AttributeUsage(System.AttributeTargets.Parameter |
        AttributeTargets.Field | AttributeTargets.Property
        , AllowMultiple = true)]
    public class FKeyAtribute: Attribute, IDisposable
    {
        public string Table;
        public CType Conection;

        public FKeyAtribute()
        {
        }

        public FKeyAtribute( string table, CType conection)
        {
            Table = table;
            Conection = conection;
        }

        public void Dispose()
        {
       
        }
    }
}
