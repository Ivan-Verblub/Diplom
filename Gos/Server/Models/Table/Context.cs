using Gos.Server.Atribute;

namespace Gos.Server.Models.Table
{
    [API("Tables/Context")]
    public class Context
    {
        [Localize("Код")]
        [AI]
        [Key(true)]
        [Invisible]
        public int id { get; set; }

        [Localize("Домен")]
        [Key(false)]
        public string domen { get; set; }
    }
}
