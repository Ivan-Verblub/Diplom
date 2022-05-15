using Gos.Server.Atribute;
using Gos.Server.Models.Table;

namespace Gos.Server.Models.Filter
{
    public class RequestFilter
    {
        [Localize("Код")]
        [Key(true)]
        [Invisible]
        public int? Id { get; set; }

        [Localize("Название")]
        public string Name { get; set; }
        [Localize("Частичное название")]
        [Atribute.Filter(Filtration.LIKE)]
        public string NameL { get; set; }

        [Localize("Обучение")]
        [Typeable(typeof(LearningHistory),typeof(LearningHistoryFilter))]
        public int? IdLearning { get; set; }

        [Localize("Коментарий")]
        public string Comment { get; set; }
        [Localize("Частичный коментарий")]
        [Atribute.Filter(Filtration.LIKE)]
        public string CommentL { get; set; }
    }
}
