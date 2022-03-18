using Gos.Server.Atribute;

namespace Gos.Server.Models.Table
{
    [API("Tables/Context")]
    public class Context
    {
        public int Id { get; set; }

        public string Domen { get; set; }
    }
}
