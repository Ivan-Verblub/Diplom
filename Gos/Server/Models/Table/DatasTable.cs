using Gos.Server.Atribute;

namespace Gos.Server.Models.Table
{
    [API("Tables/DatasTable")]
    public class DatasTable
    {
        public int IdData { get; set; }

        public string Feature { get; set; }

        public string Label { get; set; }

        public int IdDataSet { get; set; }

        public string SetName { get; set; }
    }
}
