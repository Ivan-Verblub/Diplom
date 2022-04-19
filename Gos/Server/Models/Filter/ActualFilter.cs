using Gos.Server.Atribute;
using Gos.Server.Models.Table;

namespace Gos.Server.Models.Filter
{
    public class ActualFilter
    {
        [Localize("Код")]
        [Invisible]
        [Key(true)]
        public int? IdActual { get; set; }

        [Localize("Название")]
        public string Name { get; set; }

        [Localize("Примерное название")]
        [Atribute.Filter(Filtration.LIKE)]
        public string NameL { get; set; }

        [Localize("Обучение")]
        [Typeable(typeof(LearningHistory),typeof(LearningHistoryFilter))]
        public int? IdLearn { get; set; }

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

        [Localize("Тип")]
        public int? types { get; set; }
    }
}
