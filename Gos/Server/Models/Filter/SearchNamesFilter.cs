using Gos.Server.Atribute;
using Gos.Server.Models.Table;

namespace Gos.Server.Models.Filter
{
    public class SearchNamesFilter
    {
        [Localize("Код")]
        [Key(true)]
        [Invisible]
        public int? Id { get; set; }

        [Localize("Контекст")]
        [Typeable(typeof(SearchContext),typeof(SearchContextFilter))]
        public int? IdSearch { get; set; }

        [Localize("Название контекста")]
        public string SearchName { get; set; }
        [Localize("Частичное название контекста")]
        [Atribute.Filter(Filtration.LIKE)]
        public string SearchNameL { get; set; }

        [Localize("Название")]
        public string Name { get; set; }
        [Localize("Частичное название")]
        [Atribute.Filter(Filtration.LIKE)]
        public string NameL { get; set; }
    }
}
