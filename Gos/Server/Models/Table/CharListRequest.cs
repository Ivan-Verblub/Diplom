using Gos.Server.Atribute;
using Gos.Server.Models.Filter;

namespace Gos.Server.Models.Table
{
    [API("Tables/CharListRequest")]
    public class CharListRequest
    {
        [Localize("Код")]
        [AI]
        [Key(true)]
        [Invisible]
        public int id { get; set; }

        [Localize("Название характеристи")]
        [Key(false)]
        public string name { get; set; }

        [Localize("Значение характеристики")]
        public string value { get; set; }

        [Localize("Код ТЗ")]
        [Invisible]
        [Typeable(typeof(Request),typeof(RequestFilter))]
        public int idRequest { get; set; }

        [Localize("Название ТЗ")]
        [AI]
        public string requestName { get; set; }
    }
}
