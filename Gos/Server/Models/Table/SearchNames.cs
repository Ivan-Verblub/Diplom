using Gos.Server.Atribute;
using Gos.Server.Models.Filter;

namespace Gos.Server.Models.Table
{
    [API("Tables/SearchNames")]
    public class SearchNames
    {
        [Localize("Код")]
        [AI]
        [Key(true)]
        [Invisible]
        public int id { get; set; }

        [Localize("Код контекста")]
        [Typeable(typeof(SearchContext),typeof(SearchContextFilter))]
        [Invisible]
        public int idSearch { get; set; }

        [Localize("Название контекста")]
        [AI]
        public string searchName { get; set; }

        [Localize("Имя")]
        [Key(false)]
        public string name { get; set; }

    }
}
