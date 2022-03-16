using Server.MySQL.Atributes.Filter;

namespace Server.MySQL.Tables.Filter
{
    public class DataSetFilter
    {
        [FilterAtribute(field: "iddataset",
            table: "dataset", filtType: FType.EQUAL)]
        public int IdDataSet { get; set; }
        [FilterAtribute(field: "setName",
            table: "dataset", filtType: FType.EQUAL)]
        public string? SetName { get; set; }
        [FilterAtribute(field: "setName",
            table: "dataset", filtType: FType.LIKE)]
        public string? SetNameL { get; set; }
    }
}
