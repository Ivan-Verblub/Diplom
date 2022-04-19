using Server.MySQL.Atributes.Filter;

namespace Server.MySQL.Tables.Filter
{
    public class SearchContextFilter
    {
        [FilterAtribute("idSearchContext", "SearchContext",FType.EQUAL)]
        public int? Id { get; set; }

        [FilterAtribute("name", "SearchContext", FType.EQUAL)]
        public string? Name { get; set; }
        [FilterAtribute("name", "SearchContext", FType.LIKE)]
        public string? NameL { get; set; }
    }
}
