using Server.MySQL.Atributes;

namespace Server.MySQL.Tables.Table
{
    [TableAtribute(new string[] { "contextable", "learninghistroy", 
        "dataset", "SearchContext" })]
    public class Contextable
    {
        [OrderAtribute(0)]
        [KeyAtribute(false)]
        [FKeyAtribute(table: "learninghistroy", conection: CType.INNER)]
        [DBAtribute(hide: false, table: "contextable", field: "idlearninghistroy")]
        public int Id { get; set; }

        [OrderAtribute(1)]
        [DBAtribute(hide: false, table: "learninghistroy", field: "date")]
        public DateTime Date { get; set; }

        [OrderAtribute(2)]
        [DBAtribute(hide: false, table: "learninghistroy", field: "iteration")]
        public int Iter { get; set; }

        [OrderAtribute(3)]
        [FKeyAtribute(table: "dataset", conection: CType.INNER)]
        [DBAtribute(hide: false, table: "learninghistroy", field: "iddataset")]
        public int IdDataSet { get; set; }

        [OrderAtribute(4)]
        [DBAtribute(hide: false, table: "dataset", field: "setName")]
        public string? SetName { get; set; }

        [OrderAtribute(5)]
        [DBAtribute(hide: false, table: "learninghistroy", field: "comment")]
        public string? Comment { get; set; }

        [OrderAtribute(6)]
        [DBAtribute(hide: false, table: "learninghistroy", field: "version")]
        public string? Version { get; set; }

        [OrderAtribute(7)]
        [FKeyAtribute(table: "SearchContext", conection: CType.LEFT)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "Contextable", field: "idSearchContext")]
        public int IdSearch { get; set; }

        [OrderAtribute(8)]
        [DBAtribute(hide: false, table: "SearchContext", field: "name")]
        public string? SearchName { get; set; }
    }
}
