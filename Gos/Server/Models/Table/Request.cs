using Gos.Server.Atribute;

namespace Gos.Server.Models.Table
{
    [API("Tables/Request")]
    public class Request
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string File { get; set; }

        public int IdLearning { get; set; }

        public string Comment { get; set; }
    }
}
