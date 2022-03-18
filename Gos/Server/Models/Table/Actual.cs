using Gos.Server.Atribute;

namespace Gos.Server.Models.Table
{
    [API("Table/Actual")]
    public class Actual
    {
        public int IdActual { get; set; }

        public string Name { get; set; }

        public string Conf { get; set; }

        public int IdLearningHistory { get; set; }

        public string Comment { get; set; }

        public string Version { get; set; }
    }
}
