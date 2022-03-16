using System.Data;

namespace Server.MySQL
{
    public interface ITable<T> where T : class
    {
        public DataTable Select();
        public string Insert(T obj);
        public string Update(T obj);
        public string Delete(T obj);
    }
}
