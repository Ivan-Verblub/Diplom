using Server.MySQL.Atributes.Filter;

namespace Server.MySQL.Tables.Filter
{
    public class ObjectsHistoryFilter
    {
        [FilterAtribute(field: "idobjectshistory",
            table: "objectshistory", filtType: FType.EQUAL)]
        public int? Id { get; set; }

        [FilterAtribute(field: "invnumber",
            table: "objectshistory", filtType: FType.EQUAL)]
        public string? InvNumber { get; set; }

        [FilterAtribute(field: "invnumber",
            table: "objectshistory", filtType: FType.LIKE)]
        public string? InvNumberL { get; set; }

        [FilterAtribute(field: "name",
            table: "objects", filtType: FType.EQUAL)]
        public string? Name { get; set; }

        [FilterAtribute(field: "name",
            table: "objects", filtType: FType.LIKE)]
        public string? NameL { get; set; }

        [FilterAtribute(field: "idstatus",
            table: "objectshistory", filtType: FType.EQUAL)]
        public int? IdStatus { get; set; }

        [FilterAtribute(field: "status",
            table: "sstatus", filtType: FType.EQUAL)]
        public string? Status { get; set; }

        [FilterAtribute(field: "status",
            table: "sstatus", filtType: FType.LIKE)]
        public string? StatusL { get; set; }

        [FilterAtribute(field: "idlocation",
            table: "objectshistory", filtType: FType.EQUAL)]
        public int? IdLocation { get; set; }

        [FilterAtribute(field: "location",
            table: "slocation", filtType: FType.EQUAL)]
        public string? Location { get; set; }

        [FilterAtribute(field: "location",
            table: "slocation", filtType: FType.LIKE)]
        public string? LocationL { get; set; }

        [FilterAtribute(field: "date",
            table: "objectshistory", filtType: FType.EQUAL)]
        public DateTime? Date { get; set; }

        [FilterAtribute(field: "date",
            table: "objectshistory", filtType: FType.GREATEREQUAL)]
        public DateTime? DateG { get; set; }

        [FilterAtribute(field: "date",
            table: "objectshistory", filtType: FType.LESSEREQUAL)]
        public DateTime? DateL { get; set; }

        [FilterAtribute(field: "comment",
            table: "objectshistory", filtType: FType.EQUAL)]
        public string? Comment { get; set; }

        [FilterAtribute(field: "comment",
            table: "objectshistory", filtType: FType.LIKE)]
        public string? CommentL { get; set; }
    }
}
