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

        [Localize("Код контектса")]
        [Typeable(typeof(Context),typeof(ContextFilter))]
        public int? IdContext { get; set; }

        [Localize("Домен")]
        public string Domen { get; set; }
        [Localize("Примерный домен")]
        [Atribute.Filter(Filtration.LIKE)]
        public string DomenL { get; set; }

        [Localize("Код обучения")]
        [Typeable(typeof(Contextable),typeof(ContextableFilter))]
        public int? IdContextable { get; set; }

        [Localize("Коментарий")]
        public string Comment { get; set; }
        [Localize("Примерный коментарий")]
        [Atribute.Filter(Filtration.LIKE)]
        public string CommentL { get; set; }
    }
}
