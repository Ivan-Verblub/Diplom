using Gos.Server.Atribute;

namespace Gos.Server.Models.Filter
{
    public class SearchContextFilter
    {
        [Localize("Код")]
        [Key(true)]
        [Invisible]
        public int Id { get; set; }
        [Localize("Название")]
        public string Name { get; set; }
        [Localize("Примерное название")]
        [Atribute.Filter(Filtration.LIKE)]
        public string NameL { get; set; }
    }
}
