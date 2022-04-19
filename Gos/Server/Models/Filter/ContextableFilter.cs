using Gos.Server.Atribute;
using Gos.Server.Models.Table;
using System;

namespace Gos.Server.Models.Filter
{
    public class ContextableFilter
    {
        [Localize("Код")]
        [Key(true)]
        [Invisible]
        public int? Id { get; set; }

        [Localize("Дата")]
        public DateTime? Date { get; set; }
        [Localize("Дата от")]
        public DateTime? DateG { get; set; }
        [Localize("Дата до")]
        public DateTime? DateL { get; set; }

        [Localize("Количество итераций")]
        public int? Iter { get; set; }
        [Localize("Количество итераций от")]
        public int? IterG { get; set; }
        [Localize("Количество итераций до")]
        public int? IterL { get; set; }

        [Localize("Набор данных")]
        [Typeable(typeof(DataSet),typeof(DataSetFilter))]
        public int? IdDataSet { get; set; }

        [Localize("Название набора данных")]
        public string SetName { get; set; }
        [Localize("Примерное название набора данных")]
        [Atribute.Filter(Filtration.LIKE)]
        public string SetNameL { get; set; }

        [Localize("Коментарий")]
        public string Comment { get; set; }
        [Localize("Примерный коментарий")]
        [Atribute.Filter(Filtration.LIKE)]
        public string CommentL { get; set; }

        [Localize("Версия")]
        public string Version { get; set; }
        [Localize("Примерная версия")]
        [Atribute.Filter(Filtration.LIKE)]
        public string VersionL { get; set; }

        [Localize("Контекст")]
        [Typeable(typeof(SearchContext),typeof(SearchContextFilter))]
        public int IdSearch { get; set; }

        [Localize("Название")]
        public string SearchName { get; set; }
        [Localize("Примерное название")]
        [Atribute.Filter(Filtration.LIKE)]
        public string SearchNameL { get; set; }
    }
}
