using Gos.Server.Atribute;
using Gos.Server.Models.Table;

namespace Gos.Server.Models.Filter
{
    public class DatasFilter
    {
        [Localize("Код")]
        [Key(true)]
        [Invisible]
        public int? IdData { get; set; }

        [Localize("Значение")]
        public string Feature { get; set; }

        [Localize("Частичное значение")]
        [Atribute.Filter(Filtration.LIKE)]
        public string FeatureL { get; set; }

        [Localize("Признак")]
        public string Label { get; set; }

        [Localize("Частичный признак")]
        [Atribute.Filter(Filtration.LIKE)]
        public string LabelL { get; set; }

        [Localize("Набор данных")]
        [Typeable(typeof(DataSet), typeof(DataSetFilter))]
        public int? IdDataSet { get; set; }

        [Localize("Название набора данных")]
        public string SetName { get; set; }

        [Localize("Частичное название набора данных")]
        [Atribute.Filter(Filtration.LIKE)]
        public string SetNameL { get; set; }
    }
}
