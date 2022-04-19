using Gos.Server.Atribute;
using Gos.Server.Models.Filter;
using System;

namespace Gos.Server.Models.Table
{
    [API("Tables/Contextable")]
    [Updateable]
    [Insertable]
    [Deleteable]
    public class Contextable
    {
        [Key(true)]
        [Localize("Код")]
        [Invisible]
        [Typeable(typeof(LearningHistory),typeof(LearningHistoryFilter))]
        public int? id { get; set; }

        [Localize("Дата создания")]
        [AI]
        public DateTime? date { get; set; }

        [Localize("Количество итераций")]
        [AI]
        public int? iter { get; set; }

        [Localize("Код набора данных")]
        [Typeable(typeof(DataSet),typeof(DataSetFilter))]
        [Invisible]
        [AI]
        public int? idDataSet { get; set; }

        [Localize("Название набора")]
        [AI]
        public string setName { get; set; }

        [Localize("Комментарий")]
        [AI]
        public string comment { get; set; }

        [Localize("Версия")]
        [Key(false)]
        [AI]
        public string version { get; set; }

        [Localize("Код поиска контекста")]
        [Typeable(typeof(SearchContext),typeof(SearchContextFilter))]

        [Invisible]
        public int? idSearch { get; set; }

        [Localize("Название контекста")]
        [AI]
        public string searchName { get; set; }
    }
}
