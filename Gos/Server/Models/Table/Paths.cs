using Gos.Server.Atribute;
using Gos.Server.Models.Filter;

namespace Gos.Server.Models.Table
{
    [API("Tables/Paths")]
    [Updateable]
    [Insertable]
    [Deleteable]
    public class Paths
    {
        [Localize("Код")]
        [Key(true)]
        [AI]
        [Invisible]
        public int? id { get; set; }

        [Localize("Путь к элементу")]
        [Key(false)]
        public string path { get; set; }

        [Localize("Тип")]
        [EnumList(typeof(PathType))]
        public int? type { get; set; }

        [Localize("Класс")]
        [EnumList(typeof(PathClass))]
        public int? cclass { get; set; }

        [Localize("Код контекста")]
        [Invisible]
        [Typeable(typeof(Context),typeof(ContextFilter))]
        public int? idContext { get; set; }

        [Localize("Домен")]
        [AI]
        public string domen { get; set; }
    }
}
