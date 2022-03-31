using Gos.Server.Atribute;
using Gos.Server.Models.Filter;

namespace Gos.Server.Models.Table
{
    [API("Tables/RequestInner")]
    public class RequestInner
    {
        [Localize("Код")]
        [AI]
        [Key(true)]
        [Invisible]
        public int id { get; set; }

        [Localize("Название")]
        [Key(false)]
        public string name { get; set; }

        [Localize("Стоимость")]
        public float cost { get; set; }

        [Localize("Код категории")]
        [Typeable(typeof(Scat),typeof(ScatFilter))]
        [Invisible]
        public int idCat { get; set; }

        [Localize("Категория")]
        [AI]
        public string cat { get; set; }

        [Localize("Код ТЗ")]
        [Typeable(typeof(Request), typeof(RequestFilter))]
        [Invisible]
        public int idRequest { get; set; }

        [Localize("Название ТЗ")]
        [AI]
        public string rName { get; set; }

        [Localize("Количество")]
        public int count { get; set; }
    }
}
