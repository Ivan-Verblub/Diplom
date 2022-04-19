using Gos.Server.Atribute;
using Gos.Server.Models.Table;

namespace Gos.Server.Models.Filter
{
    public class OptionsFilter
    {
        [Localize("Код")]
        [Invisible]
        [Key(true)]
        public int? Id { get; set; }

        [Localize("Тип")]
        [EnumList(typeof(OpType))]
        public int? Type { get; set; }

        [Localize("Значение")]
        public string Value { get; set; }
        [Localize("Примерное значение")]
        [Atribute.Filter(Filtration.LIKE)]
        public string ValueL { get; set; }

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
