using Gos.Server.Atribute;

namespace Gos.Server.Models.Table
{
    [API("Tables/CharListRequest")]
    public class CharListRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public int IdRequest { get; set; }

        public string RequestName { get; set; }
    }
}
