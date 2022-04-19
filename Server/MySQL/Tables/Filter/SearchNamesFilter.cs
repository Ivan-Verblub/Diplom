using Server.MySQL.Atributes.Filter;

namespace Server.MySQL.Tables.Filter
{
    public class SearchNamesFilter
    {
        [FilterAtribute("idSearchNames", "SearchNames",FType.EQUAL)]
        public int? Id { get; set; }

        [FilterAtribute("idSearchContext", "SearchNames", FType.EQUAL)]
        public int? IdSearch { get; set; }

        [FilterAtribute("name", "SearchContext", FType.EQUAL)]
        public string? SearchName { get; set; }
        [FilterAtribute("name", "SearchContext", FType.LIKE)]
        public string? SearchNameL { get; set; }

        [FilterAtribute("name", "SearchNames", FType.EQUAL)]
        public string? Name { get; set; }
        [FilterAtribute("name", "SearchNames", FType.LIKE)]
        public string? NameL { get; set; }
    }
}
