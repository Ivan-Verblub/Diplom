using Server.MySQL.Atributes.Filter;

namespace Server.MySQL.Tables.Filter
{
    public class CharListRequestFilter
    {
        [FilterAtribute("idCharList", "CharListRequest",FType.EQUAL)]
        public int? Id { get; set; }

        [FilterAtribute("Name", "CharListRequest", FType.EQUAL)]
        public string? Name { get; set; }
        [FilterAtribute("Name", "CharListRequest", FType.LIKE)]
        public string? NameL { get; set; }

        [FilterAtribute("Value", "CharListRequest", FType.EQUAL)]
        public string? Value { get; set; }
        [FilterAtribute("Value", "CharListRequest", FType.LIKE)]
        public string? ValueL { get; set; }

        [FilterAtribute("idrequestinner", "CharListRequest", FType.EQUAL)]
        public int? IdRequest { get; set; }

        [FilterAtribute("name", "requestinner", FType.EQUAL)]
        public string? RequestName { get; set; }
        [FilterAtribute("name", "requestinner", FType.LIKE)]
        public string? RequestNameL { get; set; }
    }
}
