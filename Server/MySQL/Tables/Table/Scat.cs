using Server.MySQL.Atributes;

namespace Server.MySQL.Tables.Table
{
    [TableAtribute(new string[] {"scat"})]
    public class Scat
    {
        [OrderAtribute(0)]
        [KeyAtribute(ai: true)]
        [DBAtribute(hide: false, table: "scat", field: "idcat")]
        public int IdCat { get; set; }

        [DataAtribute]
        [OrderAtribute(1)]
        [DBAtribute(hide: false, table: "scat", field: "name")]
        public string? Name { get; set; }
    }
}
