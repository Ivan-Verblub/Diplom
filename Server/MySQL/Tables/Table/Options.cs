using Server.MySQL.Atributes;

namespace Server.MySQL.Tables.Table
{
    [TableAtribute(new string[] { "Options", "Context" })]
    public class Options
    {
        [OrderAtribute(0)]
        [KeyAtribute(true)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "Options", field: "idPaths")]
        public int Id { get; set; }

        [OrderAtribute(1)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "Options", field: "Type")]
        public int Type { get; set; }

        [OrderAtribute(2)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "Options", field: "Value")]
        public int Value { get; set; }

        [OrderAtribute(3)]
        [DataAtribute]
        [FKeyAtribute(Conection = CType.INNER, Table = "Context")]
        [DBAtribute(hide: false, table: "Options", field: "idContext")]
        public int IdContext { get; set; }

        [OrderAtribute(4)]
        [DBAtribute(hide: false, table: "Context", field: "domen")]
        public string? Domen { get; set; }
    }
}
