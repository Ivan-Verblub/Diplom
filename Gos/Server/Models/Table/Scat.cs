using Gos.Server.Atribute;

namespace Gos.Server.Models.Table
{
    [API("Tables/Scat")]
    public class Scat
    {
        [Localize("Код")]
        public int idCat { get; set; }
        [Localize("Название")]
        public string name { get; set; }
    }
}
