using Gos.Server.Atribute;

namespace Gos.Server.Models.Table
{
    [API("Tables/RequestInner")]
    public class RequestInner
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Cost { get; set; }

        public int IdCat { get; set; }

        public string Cat { get; set; }

        public int IdRequest { get; set; }

        public string RName { get; set; }

        public int Count { get; set; }
    }
}
