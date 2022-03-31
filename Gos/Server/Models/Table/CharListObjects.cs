using Gos.Server.Atribute;
using Gos.Server.Models.Filter;

namespace Gos.Server.Models.Table
{
    [API("Tables/CharListObjects")]
    public class CharListObjects
    {
        [Localize("Код")]
        [AI]
        [Invisible]
        [Key(true)]
        public int id { get; set; }

        [Localize("Название характеристики")]
        [Key(false)]
        public string name { get; set; }

        [Localize("Значение характеристи")]
        public string value { get; set; }

        [Localize("Код обьекта")]
        [Invisible]
        [Typeable(typeof(Objects),typeof(ObjectsFilter))]
        public string idObject { get; set; }

        [Localize("Название обьекта")]
        [AI]
        public string objectName { get; set; }
    }
}
