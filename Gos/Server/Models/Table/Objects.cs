using Gos.Server.Atribute;
using Gos.Server.Models.Filter;

namespace Gos.Server.Models.Table
{
    [API("Tables/Objects")]
    [Updateable]
    [Deleteable]
    public class Objects
    {
        [Localize("Инвентарный номер")]
        [Key(true)]
        [Key(false)]
        public string invNumber { get; set; }

        [Localize("Название")]
        
        public string name { get; set; }

        [Localize("Стоимость")]
        public float? cost { get; set; }

        [Localize("Статус")]
        [Typeable(typeof(SStatus),typeof(SStatusFilter))]
        [Invisible]
        public int? idStatus { get; set; }

        [Localize("Статус")]
        [AI]
        public string status { get; set; }

        [Localize("Расположение")]
        [Typeable(typeof(SLocation),typeof(SLocationFilter))]
        [Invisible]
        public int? idLocation { get; set; }

        [Localize("Расположение")]
        [AI]
        public string location { get; set; }

        [Typeable(typeof(Scat),typeof(ScatFilter))]
        [Localize("Категория")]
        [Invisible]
        public int? idCat { get; set; }

        [Localize("Категория")]
        [AI]
        public string cat { get; set; }

        [Typeable(typeof(Request),typeof(RequestFilter))]
        [Localize("ТЗ")]
        [Invisible]
        public int? idRequest { get; set; }

        [Localize("Название ТЗ")]
        [AI]
        public string rName { get; set; }

    }
}
