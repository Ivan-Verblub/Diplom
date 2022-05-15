using Gos.Server.Atribute;
using Gos.Server.Models.Table;

namespace Gos.Server.Models.Filter
{
    public class ContextsFilter
    {
        [Localize("Код")]
        [Key(true)]
        [Invisible]
        public int? Id { get; set; }

        [Localize("Контекст")]
        [Typeable(typeof(Context),typeof(ContextFilter))]
        public int? IdContext { get; set; }

        [Localize("Домен")]
        public string Domen { get; set; }
        [Localize("Частичный домен")]
        [Atribute.Filter(Filtration.LIKE)]
        public string DomenL { get; set; }

        [Localize("Контекстное обучение")]
        [Typeable(typeof(Contextable),typeof(ContextableFilter))]
        public int? IdContextable { get; set; }

        [Localize("Коментарий")]
        public string Comment { get; set; }
        [Localize("Частичный коментарий")]
        [Atribute.Filter(Filtration.LIKE)]
        public string CommentL { get; set; }
    }
}
