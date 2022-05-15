using Gos.Server.Atribute;
using Gos.Server.Models.Filter;
using System;

namespace Gos.Server.Models.Table
{
    [API("Tables/LearningHistory")]
    [Updateable]
    [Deleteable]
    public class LearningHistory
    {
        [Localize("Код")]
        [Key(true)]
        [AI]
        [Invisible]
        public int? id { get; set; }

        [Localize("Дата создания")]
        public DateTime? date { get; set; }

        [Localize("Количество итераций")]
        public int? iter { get; set; }

        [Localize("Набор данных")]
        [Typeable(typeof(DataSet),typeof(DataSetFilter))]
        [Invisible]
        public int? idDataSet { get; set; }

        [Localize("Название набора")]
        [AI]
        public string setName { get; set; }

        [Localize("Комментарий")]
        public string comment { get; set; }

        [Localize("Версия")]
        [Key(false)]
        public string version { get; set; }
    }
}
