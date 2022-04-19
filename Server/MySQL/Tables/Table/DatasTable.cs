using Server.MySQL.Atributes;

namespace Server.MySQL.Tables.Table
{
    [TableAtribute(new string[] { "data","dataset"})]
    public class DatasTable
    {
        [OrderAtribute(0)]
        [KeyAtribute(ai: true)]
        [DBAtribute(hide: false, table: "data", field: "idData")]
        public int? IdData { get; set; }

        [OrderAtribute(1)]
        [DataAtribute]
        [DBAtribute(hide: false, field: "Feature", table: "data")]
        public string? Feature { get; set; }

        [OrderAtribute(2)]
        [DataAtribute]
        [DBAtribute(hide: false, field: "Label", table: "data")]
        public string? Label { get; set; }

        [OrderAtribute(3)]
        [DataAtribute]
        [FKeyAtribute(table: "dataset", conection: CType.INNER)]
        [DBAtribute(hide: false, field: "idDataSet", table: "data")]
        public int? IdDataSet { get; set; }

        [OrderAtribute(4)]
        [DBAtribute(hide: false, field: "setName", table: "dataset")]
        public string? SetName { get; set; }
    }
}
