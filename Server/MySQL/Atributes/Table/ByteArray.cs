namespace Server.MySQL.Atributes.Table
{
    [System.AttributeUsage(AttributeTargets.Field
        | AttributeTargets.Parameter | AttributeTargets.Property
        , AllowMultiple = false)]
    public class ByteArray : Attribute, IDisposable
    {
        public void Dispose()
        {
        }
    }
}
