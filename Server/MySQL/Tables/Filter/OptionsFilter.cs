using Server.MySQL.Atributes.Filter;

namespace Server.MySQL.Tables.Filter
{
    public class OptionsFilter
    {
        [FilterAtribute("idOptions", "Options", FType.EQUAL)]
        public int? Id { get; set; }

        [FilterAtribute("type", "Options", FType.EQUAL)]
        public int? Type { get; set; }

        [FilterAtribute("value", "Options", FType.EQUAL)]
        public string? Value { get; set; }
        [FilterAtribute("value", "Options", FType.LIKE)]
        public string? ValueL { get; set; }

        [FilterAtribute("idContext", "Options", FType.EQUAL)]
        public int? IdContext { get; set; }

        [FilterAtribute("domen", "Context", FType.EQUAL)]
        public string? Domen { get; set; }
        [FilterAtribute("domen", "Context", FType.LIKE)]
        public string? DomenL { get; set; }
    }
}
