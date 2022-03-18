using Gos.Server.Atribute;

namespace Gos.Server.Models.Table
{
    [API("Tables/Paths")]
    public class Paths
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public int Type { get; set; }

        public int Class { get; set; }

        public int IdContext { get; set; }

        public string Domen { get; set; }
    }
}
