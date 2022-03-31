using Gos.Server.Atribute;
using Gos.Server.Models.Filter;

namespace Gos.Server.Models.Table
{
    [API("Tables/Objects")]
    public class Objects
    {
        [Localize("Инвентарный номер")]
        [Key(true)]
        public string invNumber { get; set; }

        [Localize("Название")]
        [Key(false)]
        public string name { get; set; }

        [Localize("Стоимость")]
        public float cost { get; set; }

        [Localize("Код статуса")]
        [Typeable(typeof(SStatus),typeof(SStatusFilter))]
        [Invisible]
        public int idStatus { get; set; }

        [Localize("Статус")]
        [AI]
        public string status { get; set; }

        [Localize("Код расположения")]
        [Typeable(typeof(SLocation),typeof(SLocationFilter))]
        [Invisible]
        public int idLocation { get; set; }

        [Localize("Расположение")]
        [AI]
        public string location { get; set; }

        [Typeable(typeof(Scat),typeof(ScatFilter))]
        [Localize("Код категории")]
        [Invisible]
        public int idCat { get; set; }

        [Localize("Категория")]
        [AI]
        public string cat { get; set; }

        [Typeable(typeof(Request),typeof(RequestFilter))]
        [Localize("Код ТЗ")]
        [Invisible]
        public int idRequest { get; set; }

        [Localize("Название ТЗ")]
        [AI]
        public string rName { get; set; }

    }
}
