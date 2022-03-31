using Server.MySQL.Atributes;

namespace Server.MySQL.Tables.Table
{
    [TableAtribute(new string[] {"Paths", "Context" })]
    public class Paths
    {
        [OrderAtribute(0)]
        [KeyAtribute(true)]
        [DBAtribute(hide: false, table: "Paths", field: "idPaths")]
        public int Id { get; set; }

        [OrderAtribute(1)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "Paths", field: "Path")]
        public string? Path { get; set; }

        [OrderAtribute(2)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "Paths", field: "Type")]
        public int Type { get; set; }

        [OrderAtribute(3)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "Paths", field: "Class")]
        public int Cclass { get; set; }

        [OrderAtribute(4)]
        [DataAtribute]
        [FKeyAtribute(Conection = CType.INNER,Table = "Context")]
        [DBAtribute(hide: false, table: "Paths", field: "idContext")]
        public int IdContext { get; set; }

        [OrderAtribute(5)]
        [DBAtribute(hide: false, table: "Context", field: "domen")]
        public string? Domen { get; set; }
    }
}
