using Gos.Server.Atribute;

namespace Gos.Server.Models.Table
{
    [API("Tables/CharListObjects")]
    public class CharListObjects
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public string IdObject { get; set; }

        public string ObjectName { get; set; }
    }
}
