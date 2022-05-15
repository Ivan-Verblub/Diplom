using Gos.Server.Atribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gos.Server
{
    public enum Filtration
    {
        GREATER = 0,
        LESSER = 1,
        EQUAL = 2,
        INEQUAL = 3,
        GREATEREQUAL = 4,
        LESSEREQUAL = 5,
        LIKE = 6,
        ISNULL = 7
    }

    public enum PathType
    {
        [Localize("Таблица")]
        TABLE = 1,
        [Localize("Строка таблицы")]
        ROW = 2,
        [Localize("Столбец строки \"Значение\"")]
        COLUMNVALUE = 3,
        [Localize("Столбец строки \"Название\"")]
        COLUMNTITLE = 4,
        [Localize("Ячейка со ссылкой на элемента каталога")]
        CELL = 5,
        [Localize("Ячейка с именем для элемента каталога")]
        CELLNAME = 9,
        [Localize("Активная кнопка \"Далее\"")]
        NEXT = 10
    }

    public enum OpType
    {
        [Localize("Удалить текст со страницы")]
        REMOVE = 1,
        [Localize("Колличество элементов у базовой ссылки")]
        LINKFORMAT = 2,
        [Localize("Раздел с информацией о товаре")]
        LINKADD = 3,
        [Localize("Признак страницы с товаром")]
        LINKISAVAILIBLE = 4,
        [Localize("Время для ожидания прогрузки (мс)")]
        DELAY = 5,
        [Localize("Признак страницы с каталогом")]
        LINKISSEARCH = 6

    }

    public enum PathClass
    {
        [Localize("Формат пути \"XPath\"")]
        XPATH = 1
    }

}
