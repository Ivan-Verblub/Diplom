using Gos.Server.Atribute;

namespace Gos.Server.Models.Table
{
    [API("Tables/Options")]
    public class Options
    {
        public int Id { get; set; }

        public int Type { get; set; }

        public string Value { get; set; }

        public int IdContext { get; set; }

        public string Domen { get; set; }
    }
}
