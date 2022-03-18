using Gos.Server.Atribute;

namespace Gos.Server.Models.Table
{
    [API("Tables/Objects")]
    public class Objects
    {
        public string InvNumber { get; set; }

        public string Name { get; set; }

        public string Chars { get; set; }

        public float Cost { get; set; }

        public int IdStatus { get; set; }

        public string Status { get; set; }

        public int IdLocation { get; set; }

        public string Location { get; set; }

        public int IdCat { get; set; }

        public string Cat { get; set; }

        public int IdRequest { get; set; }

        public string RName { get; set; }

    }
}
