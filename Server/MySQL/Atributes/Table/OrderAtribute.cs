namespace Server.MySQL.Atributes
{
    [System.AttributeUsage(AttributeTargets.Parameter |
        AttributeTargets.Field | AttributeTargets.Property
        , AllowMultiple = false)]
    public class OrderAtribute: System.Attribute, IDisposable
    {
        public int Order;

        public OrderAtribute(int order)
        {
            Order = order;
        }

        public void Dispose()
        {
        }
    }
}
