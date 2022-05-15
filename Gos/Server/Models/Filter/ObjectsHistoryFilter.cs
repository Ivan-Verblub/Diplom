using Gos.Server.Atribute;
using Gos.Server.Models.Table;
using System;

namespace Gos.Server.Models.Filter
{
    public class ObjectsHistoryFilter
    {
        [Localize("Код")]
        [Key(true)]
        [Invisible]
        public int? Id { get; set; }

        [Localize("Инвентарный номер")]
        [Typeable(typeof(Objects),typeof(ObjectsFilter))]
        public string InvNumber { get; set; }
        [Localize("Частичный инвентарный номер")]
        [Atribute.Filter(Filtration.LIKE)]
        public string InvNumberL { get; set; }

        [Localize("Название")]
        public string Name { get; set; }
        [Localize("Частичное название")]
        [Atribute.Filter(Filtration.LIKE)]
        public string NameL { get; set; }

        [Localize("Статус")]
        [Typeable(typeof(SStatus), typeof(SStatusFilter))]
        public int? IdStatus { get; set; }

        [Localize("Название статуса")]
        public string Status { get; set; }
        [Localize("Частичное название статуса")]
        [Atribute.Filter(Filtration.LIKE)]
        public string StatusL { get; set; }

        [Localize("Расположение")]
        [Typeable(typeof(SLocation), typeof(SLocationFilter))]
        public int? IdLocation { get; set; }

        [Localize("Место расположение")]
        public string Location { get; set; }
        [Atribute.Filter(Filtration.LIKE)]
        [Localize("Частичное место расположение")]
        public string LocationL { get; set; }

        [Localize("Дата")]
        public DateTime? Date { get; set; }
        [Localize("Дата от")]
        public DateTime? DateG { get; set; }
        [Localize("Дата до")]
        public DateTime? DateL { get; set; }

        [Localize("Коментарий")]
        public string Comment { get; set; }
        [Localize("Частичный коментарий")]
        [Atribute.Filter(Filtration.LIKE)]
        public string CommentL { get; set; }
    }
}
