using Server.MySQL.Atributes;

namespace Server.MySQL.Tables.Table
{
    [TableAtribute(new string[] { "Context"})]
    public class Context
    {
        [OrderAtribute(0)]
        [KeyAtribute(true)]
        [DBAtribute(hide: false, table: "Context", field: "idContext")]
        public int? Id { get; set; }

        [OrderAtribute(1)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "Context", field: "domen")]
        public string? Domen { get; set; }
    }
}
