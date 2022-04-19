using Gos.Server.Atribute;
using Gos.Server.Models.Table;

namespace Gos.Server.Models.Filter
{
    public class CharListRequestFilter
    {
        [Localize("Код")]
        [Key(true)]
        [Invisible]
        public int? Id { get; set; }

        [Localize("Название")]
        public string Name { get; set; }
        [Localize("Примерное название")]
        [Atribute.Filter(Filtration.LIKE)]
        public string NameL { get; set; }

        [Localize("Значение")]
        public string Value { get; set; }
        [Localize("Примерное значение")]
        [Atribute.Filter(Filtration.LIKE)]
        public string ValueL { get; set; }

        [Localize("ТЗ")]
        [Typeable(typeof(Request),typeof(RequestFilter))]
        public int? IdRequest { get; set; }

        [Localize("Название ТЗ")]
        public string RequestName { get; set; }
        [Localize("Примерное название ТЗ")]
        [Atribute.Filter(Filtration.LIKE)]
        public string RequestNameL { get; set; }
    }
}
