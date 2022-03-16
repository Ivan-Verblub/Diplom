using Server.MySQL.Atributes.Filter;

namespace Server.MySQL.Tables.Filter
{
    public class ContextFilter
    {
        [FilterAtribute("idContext", "Context",FType.EQUAL)]
        public int Id { get; set; }

        [FilterAtribute("domen", "Context", FType.EQUAL)]
        public string? Domen { get; set; }
        [FilterAtribute("domen", "Context", FType.LIKE)]
        public string? DomenL { get; set; }
    }
}
