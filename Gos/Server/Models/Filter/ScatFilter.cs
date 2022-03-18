using Gos.Server.Atribute;

namespace Gos.Server.Models.Filter
{
    public class ScatFilter
    {
        [Localize("Id")]
        public int IdCat { get; set; }
        [Localize("Name")]
        public string Name { get; set; }
        [Localize("NameL")]
        public string NameL { get; set; }
    }
}
