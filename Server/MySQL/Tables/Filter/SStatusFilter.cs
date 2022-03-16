using Server.MySQL.Atributes.Filter;

namespace Server.MySQL.Tables.Filter
{
    public class SStatusFilter
    {
        [FilterAtribute(field: "idstatus",
            table: "sstatus", filtType: FType.EQUAL)]
        public int IdStatus { get; set; }
        [FilterAtribute(field: "status",
            table: "sstatus", filtType: FType.EQUAL)]
        public string? Status { get; set; }
        [FilterAtribute(field: "status",
            table: "sstatus", filtType: FType.LIKE)]
        public string? StatusL { get; set; }
    }
}
