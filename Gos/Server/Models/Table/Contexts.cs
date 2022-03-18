using Gos.Server.Atribute;

namespace Gos.Server.Models.Table
{
    [API("Tables/Contexts")]
    public class Contexts
    {
        public int Id { get; set; }

        public int IdContext { get; set; }

        public string Domen { get; set; }

        public int IdContextable { get; set; }

        public int IdLearning { get; set; }

        public string Comment { get; set; }
    }
}
