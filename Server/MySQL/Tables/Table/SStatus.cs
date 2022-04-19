using Server.MySQL.Atributes;

namespace Server.MySQL.Tables.Table
{
    [TableAtribute(new string[] { "sstatus"})]
    public class SStatus
    {
        [OrderAtribute(0)]
        [KeyAtribute(true)]
        [DBAtribute(false, "sstatus", "idstatus")]
        public int? IdStatus { get; set; }

        [OrderAtribute(1)]
        [DataAtribute]
        [DBAtribute(false, "sstatus", "status")]
        public string? Status { get; set; }
    }
}
