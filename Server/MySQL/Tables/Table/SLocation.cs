using Server.MySQL.Atributes;

namespace Server.MySQL.Tables.Table
{
    [TableAtribute(new string[] { "slocation"})]
    public class SLocation
    {
        [OrderAtribute(0)]
        [KeyAtribute(true)]
        [DBAtribute(false, "slocation","idlocation")]
        public int IdLocation { get; set; }

        [OrderAtribute(1)]
        [DataAtribute]
        [DBAtribute(false, "slocation", "location")]
        public string? Location { get; set; }
    }
}
