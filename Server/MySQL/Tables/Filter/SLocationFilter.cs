using Server.MySQL.Atributes.Filter;

namespace Server.MySQL.Tables.Filter
{
    public class SLocationFilter
    {
        [FilterAtribute(field: "idlocation",
            table: "slocation", filtType: FType.EQUAL)]
        public int IdLocation { get; set; }
        [FilterAtribute(field: "location",
            table: "slocation", filtType: FType.EQUAL)]
        public string? Location { get; set; }
        [FilterAtribute(field: "location",
            table: "slocation", filtType: FType.LIKE)]
        public string? LocationL { get; set; }
    }
}
