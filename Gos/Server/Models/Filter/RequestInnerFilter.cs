using Gos.Server.Atribute;
using Gos.Server.Models.Table;

namespace Gos.Server.Models.Filter
{
    public class RequestInnerFilter
    {
        [Localize("Код")]
        [Invisible]
        [Key(true)]
        public int Id { get; set; }

        [Localize("Название")]
        public string Name { get; set; }
        [Localize("Примерное название")]
        [Atribute.Filter(Filtration.LIKE)]
        public string NameL { get; set; }

        [Localize("Цена")]
        public float Cost { get; set; }
        [Localize("Цена от")]
        public float CostG { get; set; }
        [Localize("Цена до")]
        public float CostL { get; set; }

        [Localize("Категория")]
        [Typeable(typeof(Scat),typeof(ScatFilter))]
        public int IdCat { get; set; }

        [Localize("Название категории")]
        public string Cat { get; set; }
        [Atribute.Filter(Filtration.LIKE)]
        [Localize("Примерное название категории")]
        public string CatL { get; set; }

        [Localize("ТЗ")]
        [Typeable(typeof(Request), typeof(RequestFilter))]
        public int IdRequest { get; set; }

        [Localize("Название ТЗ")]
        public string RName { get; set; }
        [Localize("Примерное название ТЗ")]
        [Atribute.Filter(Filtration.LIKE)]
        public string RNameL { get; set; }

        [Localize("Количество")]
        public int Count { get; set; }
        [Localize("Количество от")]
        public int CountG { get; set; }
        [Localize("Количество до")]
        public int CountL { get; set; }
    }
}
