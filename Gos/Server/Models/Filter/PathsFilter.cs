using Gos.Server.Atribute;
using Gos.Server.Models.Table;

namespace Gos.Server.Models.Filter
{
    public class PathsFilter
    {
        [Localize("Код")]
        [Invisible]
        [Key(true)]
        public int? Id { get; set; }

        [Localize("Путь")]
        public string Path { get; set; }
        [Localize("Примерный путь")]
        [Atribute.Filter(Filtration.LIKE)]
        public string PathL { get; set; }

        [Localize("Тип")]
        [EnumList(typeof(PathType))]
        public int? Type { get; set; }

        [Localize("Класс")]
        [EnumList(typeof(PathClass))]
        public int? Class { get; set; }

        [Localize("Контекст")]
        [Typeable(typeof(Context),typeof(ContextFilter))]
        public int? IdContext { get; set; }

        [Localize("Домен")]
        public string Domen { get; set; }
        [Localize("Примерный домен")]
        [Atribute.Filter(Filtration.LIKE)]
        public string DomenL { get; set; }
    }
}
