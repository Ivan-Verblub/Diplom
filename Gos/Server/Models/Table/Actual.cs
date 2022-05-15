﻿using Gos.Server.Atribute;
using Gos.Server.Models.Filter;

namespace Gos.Server.Models.Table
{
    [API("Tables/Actual")]
    [Updateable]
    public class Actual
    {
        [Localize("Код")]
        [Key(true)]
        [AI]
        [Invisible]
        public int? idActual { get; set; }

        [Localize("Имя")]
        [Key(false)]
        public string name { get; set; }

        [Localize("Конфигурация")]
        [AI]
        [Invisible]
        public string conf { get; set; }

        [Localize("Обучение")]
        [Invisible]
        [Typeable(typeof(LearningHistory),typeof(LearningHistoryFilter))]
        public int? idLearningHistory { get; set; }

        [Localize("Коментарий")]
        [AI]
        public string comment { get; set; }

        [Localize("Версия")]
        [AI]
        public string version { get; set; }
    }
}
