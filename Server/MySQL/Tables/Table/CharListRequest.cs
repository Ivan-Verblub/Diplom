using Server.MySQL.Atributes;

namespace Server.MySQL.Tables.Table
{
    [TableAtribute(new string[] { "CharListRequest", "requestinner" })]
    public class CharListRequest
    {
        [OrderAtribute(0)]
        [KeyAtribute(true)]
        [DBAtribute(hide: false, table: "CharListRequest", field: "idCharList")]
        public int Id { get; set; }

        [OrderAtribute(1)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "CharListRequest", field: "Name")]
        public string? Name { get; set; }

        [OrderAtribute(2)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "CharListRequest", field: "Value")]
        public string? Value { get; set; }

        [OrderAtribute(3)]
        [DataAtribute]
        [FKeyAtribute(Conection = CType.INNER, Table = "requestinner")]
        [DBAtribute(hide: false, table: "CharListRequest", field: "idrequestinner")]
        public int IdRequest { get; set; }

        [OrderAtribute(4)]
        [DBAtribute(hide: false, table: "requestinner", field: "name")]
        public string? RequestName { get; set; }
    }
}
