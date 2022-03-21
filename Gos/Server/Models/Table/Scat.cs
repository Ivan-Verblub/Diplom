using Gos.Server.Atribute;

namespace Gos.Server.Models.Table
{
    [API("Tables/Scat")]
    public class Scat
    {
        [Localize("Код")]
        [Key(true)]
        public int idCat { get; set; }
        [Localize("Название")]
        [Key(false)]
        public string name { get; set; }
    }
}
