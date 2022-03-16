using Server.MySQL.Atributes;

namespace Server.MySQL.Tables.Table
{
    [TableAtribute(new string[] { "SearchNames","SearchContext" })]
    public class SearchNames
    {
        [OrderAtribute(0)]
        [KeyAtribute(true)]
        [DBAtribute(hide: false, table: "SearchNames", field: "idSearchNames")]
        public int Id { get; set; }

        [OrderAtribute(1)]
        [DataAtribute]
        [FKeyAtribute(Conection = CType.INNER, Table = "SearchContext")]
        [DBAtribute(hide: false, table: "SearchNames", field: "idSearchContext")]
        public int IdSearch { get; set; }

        [OrderAtribute(2)]
        [DBAtribute(hide: false, table: "SearchContext", field: "name")]
        public string? SearchName { get; set; }

        [OrderAtribute(3)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "SearchNames", field: "name")]
        public string? Name { get; set; }

    }
}
