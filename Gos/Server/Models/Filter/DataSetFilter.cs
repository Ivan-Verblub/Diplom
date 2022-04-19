using Gos.Server.Atribute;

namespace Gos.Server.Models.Filter
{
    public class DataSetFilter
    {
        [Localize("Код")]
        [Key(true)]
        [Invisible]
        public int? IdDataSet { get; set; }
        [Localize("Название сета")]
        public string SetName { get; set; }
        [Localize("Примерное название сета")]
        [Atribute.Filter(Filtration.LIKE)]
        public string SetNameL { get; set; }
    }
}
