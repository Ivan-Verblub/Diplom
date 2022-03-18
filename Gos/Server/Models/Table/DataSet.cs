using Gos.Server.Atribute;

namespace Gos.Server.Models.Table
{
    [API("Tables/DataSet")]
    public class DataSet
    {
        public int IdDataSet { get; set; }

        public string SetName { get; set; }

    }
}
