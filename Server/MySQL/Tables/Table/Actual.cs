using Server.MySQL.Atributes;
using Server.MySQL.Atributes.Table;

namespace Server.MySQL.Tables.Table
{
    [TableAtribute( new string[] { "actual", "learninghistroy" })]
    public class Actual
    {
        [OrderAtribute(0)]
        [KeyAtribute(ai: true)]
        [DBAtribute(hide: false, table: "actual", field: "idactual")]
        public int? IdActual { get; set; }

        [OrderAtribute(1)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "actual", field: "name")]
        public string? Name { get; set; }

        [ByteArray]
        [OrderAtribute(2)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "actual", field: "Conf")]
        public string? Conf { get; set; }

        [OrderAtribute(3)]
        [DataAtribute]
        [FKeyAtribute(table: "learninghistroy",conection: CType.INNER)]
        [DBAtribute(hide: false, table: "actual", field: "idlearninghistroy")]
        public int? IdLearningHistory { get; set; }

        [OrderAtribute(4)]
        [DBAtribute(hide: false, table: "learninghistroy", field: "comment")]
        public string? Comment { get; set; }

        [OrderAtribute(5)]
        [DBAtribute(hide: false, table: "learninghistroy", field: "version")]
        public string? Version { get; set; }

        [OrderAtribute(6)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "actual", field: "type")]
        public int? Types { get; set; }
    }
}
