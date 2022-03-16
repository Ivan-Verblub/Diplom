using Server.MySQL.Atributes.Filter;

namespace Server.MySQL.Tables.Filter
{
    public class PathsFilter
    {
        [FilterAtribute("idPaths", "Paths", FType.EQUAL)]
        public int Id { get; set; }

        [FilterAtribute("Path", "Paths", FType.EQUAL)]
        public string? Path { get; set; }
        [FilterAtribute("Path", "Paths", FType.LIKE)]
        public string? PathL { get; set; }

        [FilterAtribute("Type", "Paths", FType.EQUAL)]
        public int Type { get; set; }

        [FilterAtribute("Class", "Paths", FType.EQUAL)]
        public int Class { get; set; }

        [FilterAtribute("idContext", "Paths", FType.EQUAL)]
        public int IdContext { get; set; }

        [FilterAtribute("domen", "Context", FType.EQUAL)]
        public string? Domen { get; set; }
        [FilterAtribute("domen", "Context", FType.LIKE)]
        public string? DomenL { get; set; }
    }
}
