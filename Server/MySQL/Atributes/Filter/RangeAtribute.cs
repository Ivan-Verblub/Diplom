namespace Server.MySQL.Atributes.Filter
{
    [System.AttributeUsage(AttributeTargets.Field
        | AttributeTargets.Property | AttributeTargets.Property
        , AllowMultiple = true)]
    public class RangeAtribute: Attribute, IDisposable
    {
        public int Group;
        public int Position;

        public RangeAtribute(int group, int position)
        {
            Group = group;
            Position = position;
        }

        public void Dispose()
        {
        }
    }
}
