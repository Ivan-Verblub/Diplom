using Gos.Server.Atribute;

namespace Gos.Server.Models.Filter
{
    public class SStatusFilter
    {
        [Localize("Код расположения")]
        [Key(true)]
        [Invisible]
        public int? IdStatus { get; set; }

        [Localize("Статус")]
        public string Status { get; set; }
        [Localize("Частичный статус")]
        [Atribute.Filter(Filtration.LIKE)]
        public string StatusL { get; set; }
    }
}
