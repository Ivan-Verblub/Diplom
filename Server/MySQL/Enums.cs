namespace Server.MySQL
{
    public enum CType
    { 
        INNER = 0,
        LEFT = 1,
        RIGHT = 2
    }

    public enum FType
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
        SUBMIT = 8,
        CELLNAME = 9,
        NEXT = 10
    }

    public enum ActType
    { 
        DEFINE = 1,
        COMPARE = 2
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
