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
        [Localize("Примерное название")]
        [Atribute.Filter(Filtration.LIKE)]
        public string NameL { get; set; }

        [Localize("Значение")]
        public string Value { get; set; }
        [Localize("Примерное значение")]
        [Atribute.Filter(Filtration.LIKE)]
        public string ValueL { get; set; }

        [Localize("Инвентарный номер")]
        public string IdObject { get; set; }
        [Localize("Примерный инвентарный номер")]
        [Atribute.Filter(Filtration.LIKE)]
        public string IdObjectL { get; set; }

        [Localize("Название обькта")]
        public string ObjectName { get; set; }
        [Localize("Примерное название обьекта")]
        [Atribute.Filter(Filtration.LIKE)]
        public string ObjectNameL { get; set; }
    }
}
