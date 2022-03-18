using Gos.Server.Atribute;

namespace Gos.Server.Models.Table
{
    [API("Tables/SearchContext")]
    public class SearchContext
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
