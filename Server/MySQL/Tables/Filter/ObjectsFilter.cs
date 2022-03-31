using Server.MySQL.Atributes.Filter;

namespace Server.MySQL.Tables.Filter
{
    public class ObjectsFilter
    {
        [FilterAtribute(field: "invnumber",
            table: "objects", filtType: FType.EQUAL)]
        public string? InvNumber { get; set; }

        [FilterAtribute(field: "invnumber",
            table: "objects", filtType: FType.LIKE)]
        public string? InvNumberL { get; set; }

        [FilterAtribute(field: "name",
            table: "objects", filtType: FType.EQUAL)]
        public string? Name { get; set; }

        [FilterAtribute(field: "name",
            table: "objects", filtType: FType.LIKE)]
        public string? NameL { get; set; }

        [FilterAtribute(field: "cost",
            table: "objects", filtType: FType.EQUAL)]
        public int Cost { get; set; }

        [RangeAtribute(0,0)]
        [FilterAtribute(field: "cost",
            table: "objects", filtType: FType.GREATEREQUAL)]
        public int CostG { get; set; }

        [RangeAtribute(0, 1)]
        [FilterAtribute(field: "cost",
            table: "objects", filtType: FType.LESSEREQUAL)]
        public int CostL { get; set; }

        [FilterAtribute(field: "idstatus",
            table: "objects", filtType: FType.EQUAL)]
        public int IdStatus { get; set; }

        [FilterAtribute(field: "status",
            table: "sstatus", filtType: FType.EQUAL)]
        public string? Status { get; set; }

        [FilterAtribute(field: "status",
            table: "sstatus", filtType: FType.LIKE)]
        public string? StatusL { get; set; }

        [FilterAtribute(field: "idlocation",
            table: "objects", filtType: FType.EQUAL)]
        public int IdLocation { get; set; }

        [FilterAtribute(field: "idlocation",
            table: "slocation", filtType: FType.EQUAL)]
        public string? Location { get; set; }

        [FilterAtribute(field: "idlocation",
            table: "slocation", filtType: FType.LIKE)]
        public string? LocationL { get; set; }

        [FilterAtribute(field: "idcat",
            table: "objects", filtType: FType.EQUAL)]
        public int IdCat { get; set; }

        [FilterAtribute(field: "name",
            table: "scat", filtType: FType.EQUAL)]
        public string? NameC { get; set; }

        [FilterAtribute(field: "name",
            table: "scat", filtType: FType.LIKE)]
        public string? NameCL { get; set; }

        [FilterAtribute(field: "idrequest",
            table: "objects", filtType: FType.EQUAL)]
        public int IdRequest { get; set; }

        [FilterAtribute(field: "name",
            table: "request", filtType: FType.EQUAL)]
        public string? NameR { get; set; }

        [FilterAtribute(field: "name",
            table: "request", filtType: FType.LIKE)]
        public string? NameRL { get; set; }
    }
}
