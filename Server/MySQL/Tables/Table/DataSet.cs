using Server.MySQL.Atributes;

namespace Server.MySQL.Tables.Table
{
    [TableAtribute(new string[] {"dataset"})]
    public class DataSet
    {
        [OrderAtribute(0)]
        [KeyAtribute(ai:true)]
        [DBAtribute(hide: false, table: "dataset", field: "iddataset")]
        public int IdDataSet { get; set; }

        [DataAtribute]
        [OrderAtribute(1)]
        [DBAtribute(hide: false, table: "dataset", field: "setName")]
        public string? SetName { get; set; }

    }
}
