using Gos.Server.Atribute;
using Gos.Server.Models.Filter;
using System;

namespace Gos.Server.Models.Table
{
    [API("Tables/ObjectsHistory")]
    public class ObjectsHistory
    {
        [Localize("Код")]
        [Key(true)]
        [AI]
        [Invisible]
        public int id { get; set; }

        [Localize("Инвентарный номер")]
        [Typeable(typeof(LearningHistory),typeof(LearningHistoryFilter))]
        [Invisible]
        public string invNumber { get; set; }

        [Localize("Название")]
        public string name { get; set; }

        [Localize("Код статуса")]
        [Typeable(typeof(SStatus),typeof(SStatusFilter))]
        [Invisible]
        public int idStatus { get; set; }

        [Localize("Назание статуса")]
        [AI]
        public string status { get; set; }

        [Localize("Код расположения")]
        [Typeable(typeof(SLocation), typeof(SLocationFilter))]
        [Invisible]
        public int idLocation { get; set; }

        [Localize("Расположение")]
        [AI]
        public string location { get; set; }

        [Localize("Дата")]
        public DateTime date { get; set; }

        [Localize("Комментарий")]
        [Key(false)]
        public string comment { get; set; }
    }
}
