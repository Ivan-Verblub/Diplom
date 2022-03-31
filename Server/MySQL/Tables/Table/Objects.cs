using Server.MySQL.Atributes;

namespace Server.MySQL.Tables.Table
{
    [TableAtribute(new string[]{ "objects","request","sstatus","slocation","scat"})]
    public class Objects
    {
        [OrderAtribute(order:0)]
        [KeyAtribute(ai:false)]
        [DataAtribute]
        [DBAtribute(hide:false,table:"objects",field:"invnumber")]
        public string? InvNumber { get; set; }

        [OrderAtribute(order: 1)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "objects", field: "name")]
        public string? Name { get; set; }

        [OrderAtribute(order: 2)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "objects", field: "cost")]
        public float Cost { get; set; }

        [OrderAtribute(3)]
        [DataAtribute]
        [FKeyAtribute(table: "sstatus", conection:CType.INNER)]
        [DBAtribute(hide: false, table: "objects", field: "idstatus")]
        public int IdStatus { get; set; }

        [OrderAtribute(order: 4)]
        [DBAtribute(hide: false, table: "sstatus", field: "status")]
        public string? Status { get; set; }

        [OrderAtribute(5)]
        [DataAtribute]
        [FKeyAtribute(table: "slocation", conection: CType.INNER)]
        [DBAtribute(hide: false, table: "objects", field: "idlocation")]
        public int IdLocation { get; set; }

        [OrderAtribute(order: 6)]
        [DBAtribute(hide: false, table: "slocation", field: "location")]
        public string? Location { get; set; }

        [OrderAtribute(7)]
        [DataAtribute]
        [FKeyAtribute(table: "scat", conection: CType.INNER)]
        [DBAtribute(hide: false, table: "objects", field: "idcat")]
        public int IdCat { get; set; }

        [OrderAtribute(order: 8)]
        [DBAtribute(hide: false, table: "scat", field: "name")]
        public string? Cat { get; set; }

        [OrderAtribute(9)]
        [DataAtribute]
        [FKeyAtribute(table: "request", conection: CType.INNER)]
        [DBAtribute(hide: false, table: "request", field: "idrequest")]
        public int IdRequest { get; set; }

        [OrderAtribute(order: 10)]
        [DBAtribute(hide: false, table: "request", field: "name")]
        public string? RName { get; set; }

    }
}
