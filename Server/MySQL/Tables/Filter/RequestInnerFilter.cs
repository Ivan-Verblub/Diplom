using Server.MySQL.Atributes.Filter;

namespace Server.MySQL.Tables.Filter
{
    public class RequestInnerFilter
    {
        [FilterAtribute(field: "idrequestinner",
            table: "requestinner", filtType: FType.EQUAL)]
        public int? Id { get; set; }

        [FilterAtribute(field: "name",
            table: "requestinner", filtType: FType.EQUAL)]
        public string? Name { get; set; }

        [FilterAtribute(field: "name",
            table: "requestinner", filtType: FType.LIKE)]
        public string? NameL { get; set; }

        [FilterAtribute(field: "cost",
            table: "requestinner", filtType: FType.EQUAL)]
        public float? Cost { get; set; }

        [RangeAtribute(0,0)]
        [FilterAtribute(field: "cost",
            table: "requestinner", filtType: FType.GREATEREQUAL)]
        public float? CostG { get; set; }

        [RangeAtribute(0, 1)]
        [FilterAtribute(field: "cost",
            table: "requestinner", filtType: FType.LESSEREQUAL)]
        public float? CostL { get; set; }

        [FilterAtribute(field: "idcat",
            table: "requestinner", filtType: FType.EQUAL)]
        public int? IdCat { get; set; }

        [FilterAtribute(field: "name",
            table: "scat", filtType: FType.EQUAL)]
        public string? Cat { get; set; }

        [FilterAtribute(field: "name",
            table: "scat", filtType: FType.LIKE)]
        public string? CatL { get; set; }

        [FilterAtribute(field: "idrequest",
            table: "requestinner", filtType: FType.EQUAL)]
        public int? IdRequest { get; set; }

        [FilterAtribute(field: "name",
            table: "request", filtType: FType.EQUAL)]
        public string? RName { get; set; }

        [FilterAtribute(field: "name",
            table: "request", filtType: FType.LIKE)]
        public string? RNameL { get; set; }

        [FilterAtribute(field: "count",
            table: "requestinner", filtType: FType.EQUAL)]
        public int? Count { get; set; }

        [RangeAtribute(1, 0)]
        [FilterAtribute(field: "count",
            table: "requestinner", filtType: FType.GREATEREQUAL)]
        public int? CountG { get; set; }

        [RangeAtribute(1, 1)]
        [FilterAtribute(field: "count",
            table: "requestinner", filtType: FType.LESSEREQUAL)]
        public int? CountL { get; set; }
    }
}
