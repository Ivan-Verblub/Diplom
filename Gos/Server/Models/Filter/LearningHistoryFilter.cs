using Gos.Server.Atribute;
using Gos.Server.Models.Table;
using System;

namespace Gos.Server.Models.Filter
{
    public class LearningHistoryFilter
    {

        [Localize("Инвентарный номер")]
        [Invisible]
        [Key(true)]
        public int? Id { get; set; }

        [Localize("Дата")]
        public DateTime? Date { get; set; }
        [Localize("Дата от")]
        public DateTime? DateBegin { get; set; }
        [Localize("Дата до")]
        public DateTime? DateEnd { get; set; }

        [Localize("Количество итераций")]
        public int? iter { get; set; }

        [Localize("Набор данных")]
        [Typeable(typeof(DataSet),typeof(DataSetFilter))]
        public int? IdDataSet { get; set; }

        [Localize("Коментарий")]
        public string Comment { get; set; }
        [Localize("Частичный коментарий")]
        [Atribute.Filter(Filtration.LIKE)]
        public string CommentL { get; set; }

        [Localize("Версия")]
        public string Version { get; set; }
        [Localize("Частичная версия")]
        [Atribute.Filter(Filtration.LIKE)]
        public string VersionL { get; set; }
    }
}
