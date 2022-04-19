using Gos.Server.Atribute;

namespace Gos.Server.Models.Filter
{
    public class ContextFilter
    {
        [Localize("Код")]
        [Key(true)]
        [Invisible]
        public int? Id { get; set; }

        [Localize("Домен")]
        public string Domen { get; set; }
        [Localize("Применрный домен")]
        [Atribute.Filter(Filtration.LIKE)]
        public string DomenL { get; set; }
    }
}
