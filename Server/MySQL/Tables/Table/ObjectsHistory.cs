using Server.MySQL.Atributes;

namespace Server.MySQL.Tables.Table
{
    [TableAtribute(new string[]{ "objectshistory","sstatus","slocation","objects" })]
    public class ObjectsHistory
    {
        [OrderAtribute(0)]
        [KeyAtribute(ai: true)]
        [DBAtribute(hide:false,table: "objectshistory",field: "idobjectshistory")]
        public int? Id { get; set; }

        [OrderAtribute(1)]
        [DataAtribute]
        [FKeyAtribute(table: "objects", conection: CType.INNER)]
        [DBAtribute(hide: false, table: "objectshistory", field: "invnumber")]
        public string? InvNumber { get; set; }

        [OrderAtribute(2)]
        [DBAtribute(hide: false, table: "objects", field: "name")]
        public string? Name { get; set; }

        [OrderAtribute(3)]
        [DataAtribute]
        [FKeyAtribute(table: "sstatus", conection: CType.INNER)]
        [DBAtribute(hide: false, table: "objectshistory", field: "idstatus")]
        public int? IdStatus { get; set; }

        [OrderAtribute(4)]
        [DBAtribute(hide: false, table: "sstatus", field: "status")]
        public string? Status { get; set; }

        [OrderAtribute(5)]
        [DataAtribute]
        [FKeyAtribute(table: "slocation", conection: CType.INNER)]
        [DBAtribute(hide: false, table: "objectshistory", field: "idlocation")]
        public int? IdLocation { get; set; }

        [OrderAtribute(6)]
        [DBAtribute(hide: false, table: "slocation", field: "location")]
        public string? Location { get; set; }

        [OrderAtribute(7)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "objectshistory", field: "date")]
        public DateTime? Date { get; set; }

        [OrderAtribute(8)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "objectshistory", field: "comment")]
        public string? comment { get; set; }
    }
}
