using Gos.Server.Atribute;
using Gos.Server.Models.Filter;

namespace Gos.Server.Models.Table
{
    [API("Tables/Request")]
    [Updateable]
    [Deleteable]
    public class Request
    {
        [Localize("Код")]
        [AI]
        [Key(true)]
        [Invisible]
        public int id { get; set; }

        [Localize("Название")]
        [Key(false)]
        public string name { get; set; }

        [Localize("Файл")]
        [Invisible]
        public string file { get; set; }

        [Localize("Код обучения")]
        [Invisible]
        [Typeable(typeof(LearningHistory),typeof(LearningHistoryFilter))]
        public int idLearning { get; set; }

        [Localize("Комментарий")]
        [AI]
        public string comment { get; set; }
    }
}
