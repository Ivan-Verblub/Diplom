using Gos.Server.Atribute;

namespace Gos.Server.Models.Table
{
    [API("Tables/SearchContext")]
    public class SearchContext
    {
        [Localize("Код")]
        [AI]
        [Key(true)]
        [Invisible]
        public int id { get; set; }
        [Localize("Название контекста")]
        [Key(false)]
        public string name { get; set; }
    }
}
