using Gos.Server.Atribute;
using Gos.Server.Models.Filter;

namespace Gos.Server.Models.Table
{
    [API("Tables/Options")]
    [Updateable]
    [Insertable]
    [Deleteable]
    public class Options
    {
        [Localize("Код")]
        [Key(true)]
        [AI]
        [Invisible]
        public int id { get; set; }

        [Localize("Код типа")]
        [EnumList(typeof(OpType))]
        public int type { get; set; }

        [Localize("Значение")]
        [Key(false)]
        public string value { get; set; }

        [Localize("Код контекста")]
        [Typeable(typeof(Context),typeof(ContextFilter))]
        [Invisible]
        public int idContext { get; set; }

        [Localize("Домен")]
        [AI]
        public string domen { get; set; }
    }
}
