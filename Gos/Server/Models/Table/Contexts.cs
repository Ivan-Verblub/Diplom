using Gos.Server.Atribute;
using Gos.Server.Models.Filter;

namespace Gos.Server.Models.Table
{
    [API("Tables/Contexts")]
    [Updateable]
    [Insertable]
    [Deleteable]
    public class Contexts
    {
        [Localize("Код")]
        [AI]
        [Key(true)]
        [Invisible]
        public int id { get; set; }

        [Localize("Код контекста")]
        [Typeable(typeof(Context),typeof(ContextFilter))]
        [Invisible]
        public int idContext { get; set; }

        [Localize("Домен")]
        [AI]
        [Key(false)]
        public string domen { get; set; }

        [Localize("Код обучения")]
        [Typeable(typeof(Contextable), typeof(ContextableFilter))]
        [Invisible]
        public int idContextable { get; set; }

        [Localize("Код обучения")]
        [Invisible]
        [AI]
        public int idLearning { get; set; }

        [Localize("Коментарий")]
        [AI]
        public string comment { get; set; }
    }
}
