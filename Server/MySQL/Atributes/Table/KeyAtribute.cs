namespace Server.MySQL.Atributes
{
    [System.AttributeUsage(AttributeTargets.Field
        | AttributeTargets.Parameter | AttributeTargets.Property
        , AllowMultiple = false)]
    public class KeyAtribute: Attribute, IDisposable
    {
        public bool AI;

        public KeyAtribute(bool ai)
        {
            AI = ai;
        }

        public void Dispose()
        {
        }
    }
}
