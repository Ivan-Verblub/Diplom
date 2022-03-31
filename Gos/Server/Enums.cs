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
        TABLE = 1,
        ROW = 2,
        COLUMNVALUE = 3,
        COLUMNTITLE = 4,
        CELL = 5,
        SEARCH = 6,
        FULLSEARCH = 7,
        SUBMIT = 8
    }

    public enum OpType
    {
        REMOVE = 1,
        LINKFORMAT = 2,
        LINKADD = 3,
        LINKISAVAILIBLE = 4,
        DELAY = 5,
        LINKISSEARCH = 6

    }

    public enum PathClass
    {
        XPATH = 1
    }
}
