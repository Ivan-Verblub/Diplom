using Gos.Server.Atribute;
using Gos.Server.Models.Table;

namespace Gos.Server.Models.Filter
{
    public class ScatFilter
    {
        [Localize("Код категории")]
        public int IdCat { get; set; }
        [Localize("Название категории")]
        public string Name { get; set; }
        [Localize("Примерное название категории")]
        [Atribute.Filter(Filtration.LIKE)]
        public string NameL { get; set; }
    }
}
