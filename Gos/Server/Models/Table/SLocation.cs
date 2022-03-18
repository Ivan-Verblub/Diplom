using Gos.Server.Atribute;

namespace Gos.Server.Models.Table
{
    [API("Tables/SLocation")]
    public class SLocation
    {
        public int IdLocation { get; set; }

        public string Location { get; set; }
    }
}
