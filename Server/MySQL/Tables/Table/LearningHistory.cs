using Server.MySQL.Atributes;

namespace Server.MySQL.Tables
{
    [TableAtribute(new string[] { "learninghistroy", "dataset","user" })]
    public class LearningHistory
    {
        [OrderAtribute(0)]
        [KeyAtribute(ai: true)]
        [DBAtribute(hide: false,table: "learninghistroy", field: "idlearninghistroy")]
        public int Id { get; set; }

        [OrderAtribute(order: 1)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "learninghistroy", field: "date")]
        public DateTime Date { get; set; }

        [OrderAtribute(order: 2)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "learninghistroy", field: "iteration")]
        public int Iter { get; set; }

        [OrderAtribute(3)]
        [FKeyAtribute(table: "dataset", conection: CType.INNER)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "learninghistroy", field: "iddataset")]
        public int IdDataSet { get; set; }

        [OrderAtribute(order: 4)]
        [DBAtribute(hide: false, table: "dataset", field: "setName")]
        public string? SetName { get; set; }

        [OrderAtribute(order: 5)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "learninghistroy", field: "comment")]
        public string? Comment { get; set; }

        [OrderAtribute(order: 6)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "learninghistroy", field: "version")]
        public string? Version { get; set; }
    }
}
