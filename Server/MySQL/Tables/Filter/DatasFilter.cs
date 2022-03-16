using Server.MySQL.Atributes.Filter;

namespace Server.MySQL.Tables.Filter
{
    public class DatasFilter
    {
        [FilterAtribute(field: "idData",
            table: "data", filtType: FType.EQUAL)]
        public int IdData { get; set; }

        [FilterAtribute(field: "Feature",
            table: "data", filtType: FType.EQUAL)]
        public string? Feature { get; set; }

        [FilterAtribute(field: "Feature",
            table: "data", filtType: FType.LIKE)]
        public string? FeatureL { get; set; }

        [FilterAtribute(field: "Label",
            table: "data", filtType: FType.EQUAL)]
        public string? Label { get; set; }

        [FilterAtribute(field: "Label",
            table: "data", filtType: FType.LIKE)]
        public string? LabelL { get; set; }

        [FilterAtribute(field: "idDataSet",
            table: "data", filtType: FType.EQUAL)]
        public int IdDataSet { get; set; }

        [FilterAtribute(field: "setName",
            table: "dataset", filtType: FType.EQUAL)]
        public string? SetName { get; set; }

        [FilterAtribute(field: "setName",
            table: "dataset", filtType: FType.LIKE)]
        public string? SetNameL { get; set; }
    }
}
