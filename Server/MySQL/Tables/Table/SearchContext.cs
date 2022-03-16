using Server.MySQL.Atributes;

namespace Server.MySQL.Tables.Table
{
    [TableAtribute(new string[] { "SearchContext"})]
    public class SearchContext
    {
        [OrderAtribute(0)]
        [KeyAtribute(true)]
        [DBAtribute(hide: false, table: "SearchContext", field: "name")]
        public int Id { get; set; }

        [OrderAtribute(1)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "SearchContext", field: "name")]
        public string? Name { get; set; }
    }
}
