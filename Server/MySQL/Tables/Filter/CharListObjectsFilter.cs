using Server.MySQL.Atributes.Filter;

namespace Server.MySQL.Tables.Filter
{
    public class CharListObjectsFilter
    {
        [FilterAtribute("idCharList", "CharListObjects", FType.EQUAL)]
        public int? Id { get; set; }

        [FilterAtribute("Name", "CharListObjects", FType.EQUAL)]
        public string? Name { get; set; }
        [FilterAtribute("Name", "CharListObjects", FType.LIKE)]
        public string? NameL { get; set; }

        [FilterAtribute("Value", "CharListObjects", FType.EQUAL)]
        public string? Value { get; set; }
        [FilterAtribute("Value", "CharListObjects", FType.LIKE)]
        public string? ValueL { get; set; }

        [FilterAtribute("invnumber", "CharListObjects", FType.EQUAL)]
        public string? IdObject { get; set; }
        [FilterAtribute("invnumber", "CharListObjects", FType.LIKE)]
        public string? IdObjectL { get; set; }

        [FilterAtribute("name", "objects", FType.EQUAL)]
        public string? ObjectName { get; set; }
        [FilterAtribute("name", "objects", FType.LIKE)]
        public string? ObjectNameL { get; set; }
    }
}
