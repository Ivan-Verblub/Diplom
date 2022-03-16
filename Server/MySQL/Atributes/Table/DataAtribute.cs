namespace Server.MySQL.Atributes
{
    [System.AttributeUsage(AttributeTargets.Field
        | AttributeTargets.Parameter | AttributeTargets.Property
        , AllowMultiple = false)]
    public class DataAtribute : Attribute, IDisposable
    {
        public void Dispose()
        {
        }
    }
}
