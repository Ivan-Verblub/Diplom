using Gos.Server.Atribute;

namespace Gos.Server.Models.Filter
{
    public class CharListObjectsFilter
    {
        [Localize("Код")]
        [Invisible]
        [Key(true)]
        public int? Id { get; set; }

        [Localize("Название")]
        public string Name { get; set; }
        [Localize("Частичное название")]
        [Atribute.Filter(Filtration.LIKE)]
        public string NameL { get; set; }

        [Localize("Значение")]
        public string Value { get; set; }
        [Localize("Частичное значение")]
        [Atribute.Filter(Filtration.LIKE)]
        public string ValueL { get; set; }

        [Localize("Инвентарный номер")]
        public string IdObject { get; set; }
        [Localize("Частичный инвентарный номер")]
        [Atribute.Filter(Filtration.LIKE)]
        public string IdObjectL { get; set; }

        [Localize("Название обькта")]
        public string ObjectName { get; set; }
        [Localize("Частичное название обьекта")]
        [Atribute.Filter(Filtration.LIKE)]
        public string ObjectNameL { get; set; }
    }
}
