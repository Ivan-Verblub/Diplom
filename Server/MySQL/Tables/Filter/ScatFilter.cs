using Server.MySQL.Atributes.Filter;

namespace Server.MySQL.Tables.Filter
{
    public class ScatFilter
    {
        [FilterAtribute(field: "idcat",
            table: "scat", filtType: FType.EQUAL)]
        public int? IdCat { get; set; }
        [FilterAtribute(field: "name",
            table: "scat", filtType: FType.EQUAL)]
        public string? Name { get; set; }
        [FilterAtribute(field: "name",
            table: "scat", filtType: FType.LIKE)]
        public string? NameL { get; set; }
    }
}
