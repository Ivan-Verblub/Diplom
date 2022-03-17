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
        COLUMNTITLE = 4
    }

    public enum OpType
    {
        CLEAR = 1

    }

    public enum PathClass
    { 
        XPATH = 1
    }



}
