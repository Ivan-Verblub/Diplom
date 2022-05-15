using Gos.Server.Atribute;
using Gos.Server.Models.Filter;

namespace Gos.Server.Models.Table
{
    [API("Tables/Data")]
    [Updateable]
    [Insertable]
    [Deleteable]
    public class DatasTable
    {
        [Localize("Код")]
        [AI]
        [Key(true)]
        [Invisible]
        public int? idData { get; set; }

        [Localize("Значение")]
        [Key(false)]
        public string feature { get; set; }

        [Localize("Признак")]
        public string label { get; set; }

        [Localize("Набор данных")]
        [Invisible]
        [Typeable(typeof(DataSet),typeof(DataSetFilter))]
        public int? idDataSet { get; set; }

        [Localize("Название набора данных")]
        [AI]
        public string setName { get; set; }
    }
}
