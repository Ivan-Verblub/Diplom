namespace Gos.Server.Models.Filter
{
    public class CharListRequestFilter
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string NameL { get; set; }

        public string Value { get; set; }
        public string ValueL { get; set; }

        public int IdRequest { get; set; }

        public string RequestName { get; set; }
        public string RequestNameL { get; set; }
    }
}
