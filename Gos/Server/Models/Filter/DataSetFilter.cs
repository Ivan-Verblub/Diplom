using Gos.Server.Atribute;

namespace Gos.Server.Models.Filter
{
    public class DataSetFilter
    {
        [Localize("Код")]
        [Key(true)]
        [Invisible]
        public int? IdDataSet { get; set; }
        [Localize("Название набора данных")]
        public string SetName { get; set; }
        [Localize("Частичное название набора данных")]
        [Atribute.Filter(Filtration.LIKE)]
        public string SetNameL { get; set; }
    }
}
