using System.Data;

namespace Server.MySQL
{
    public interface IFilter<T> where T: class
    {
        public DataTable Select(T obj);
    }
}
