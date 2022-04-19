using Server.MySQL.Atributes;

namespace Server.MySQL.Tables.Table
{
    [TableAtribute(new string[]{ "requestinner", "scat", "request" })]
    public class RequestInner
    {
        [OrderAtribute(order: 0)]
        [KeyAtribute(ai: false)]
        [DBAtribute(hide: false, table: "requestinner", field: "idrequestinner")]
        public int? Id { get; set; }

        [OrderAtribute(order: 1)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "requestinner", field: "name")]
        public string? Name { get; set; }

        [OrderAtribute(order: 2)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "requestinner", field: "cost")]
        public float? Cost { get; set; }

        [OrderAtribute(order: 3)]
        [DataAtribute]
        [FKeyAtribute(table: "scat", conection: CType.LEFT)]
        [DBAtribute(hide: false, table: "requestinner", field: "idcat")]
        public int? IdCat { get; set; }

        [OrderAtribute(order: 4)]
        [DBAtribute(hide: false, table: "scat", field: "name")]
        public string? Cat { get; set; }

        [OrderAtribute(order: 5)]
        [DataAtribute]
        [FKeyAtribute(table: "request", conection: CType.INNER)]
        [DBAtribute(hide: false, table: "requestinner", field: "idrequest")]
        public int? IdRequest { get; set; }

        [OrderAtribute(order: 6)]
        [DBAtribute(hide: false, table: "request", field: "name")]
        public string? RName { get; set; }

        [DataAtribute]
        [OrderAtribute(order: 7)]
        [DBAtribute(hide: false, table: "requestinner", field: "count")]
        public int? Count { get; set; }
    }
}
