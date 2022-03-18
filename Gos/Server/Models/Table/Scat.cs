using Gos.Server.Atribute;

namespace Gos.Server.Models.Table
{
    [API("Tables/Scat")]
    public class Scat
    {
        public int idCat { get; set; }

        public string name { get; set; }
    }
}
