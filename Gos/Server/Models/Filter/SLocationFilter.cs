using Gos.Server.Atribute;

namespace Gos.Server.Models.Filter
{
    public class SLocationFilter
    {
        [Localize("Код расположения")]
        [Key(true)]
        [Invisible]
        public int IdLocation { get; set; }

        [Localize("Расположение")]
        public string Location { get; set; }
        [Localize("Примерное расположение")]
        [Atribute.Filter(Filtration.LIKE)]
        public string LocationL { get; set; }
    }
}
