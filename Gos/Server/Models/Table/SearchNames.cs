using Gos.Server.Atribute;

namespace Gos.Server.Models.Table
{
    [API("Tables/SearchNames")]
    public class SearchNames
    {
        public int Id { get; set; }

        public int IdSearch { get; set; }

        public string SearchName { get; set; }

        public string Name { get; set; }

    }
}
