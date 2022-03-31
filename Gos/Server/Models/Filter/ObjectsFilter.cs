using Gos.Server.Atribute;
using Gos.Server.Models.Table;

namespace Gos.Server.Models.Filter
{
    public class ObjectsFilter
    {
        [Localize("Инвентарный номер")]
        [Key(true)]
        public string InvNumber { get; set; }
        [Localize("Примерный инвентарный номер")]
        [Atribute.Filter(Filtration.LIKE)]
        public string InvNumberL { get; set; }

        [Localize("Название")]
        public string Name { get; set; }
        [Localize("Примерное название")]
        [Atribute.Filter(Filtration.LIKE)]
        public string NameL { get; set; }

        [Localize("Стоимость")]
        public int Cost { get; set; }
        [Localize("Стоимость от")]
        public int CostG { get; set; }
        [Localize("Стоимость до")]
        public int CostL { get; set; }

        [Localize("Статус")]
        [Typeable(typeof(SStatus),typeof(SStatusFilter))]
        public int IdStatus { get; set; }
        
        [Localize("Название статуса")]
        public string Status { get; set; }
        [Localize("Примерное название статуса")]
        [Atribute.Filter(Filtration.LIKE)]
        public string StatusL { get; set; }

        [Localize("Расположение")]
        [Typeable(typeof(SLocation), typeof(SLocationFilter))]
        public int IdLocation { get; set; }

        [Localize("Название расположения")]
        public string Location { get; set; }
        [Localize("Примерное расположения")]
        [Atribute.Filter(Filtration.LIKE)]
        public string LocationL { get; set; }

        [Localize("Категория")]
        [Typeable(typeof(Scat),typeof(ScatFilter))]
        public int IdCat { get; set; }

        [Localize("Название категории")]
        public string NameC { get; set; }
        [Localize("Примерное название категории")]
        [Atribute.Filter(Filtration.LIKE)]
        public string NameCL { get; set; }

        [Localize("ТЗ")]
        [Typeable(typeof(Request), typeof(RequestFilter))]
        public int IdRequest { get; set; }

        [Localize("Название ТЗ")]
        public string NameR { get; set; }
        [Localize("Примерное название ТЗ")]
        [Atribute.Filter(Filtration.LIKE)]
        public string NameRL { get; set; }
    }
}
