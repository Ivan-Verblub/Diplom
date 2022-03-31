using Server.MySQL.Atributes;

namespace Server.MySQL.Tables.Table
{
    [TableAtribute(new string[] { "Contexts","Context", "Contextable", "learninghistroy" })]
    public class Contexts
    {
        [OrderAtribute(0)]
        [KeyAtribute(true)]
        [DBAtribute(hide: false, table: "Contexts", field: "idContexts")]
        public int Id { get; set; }

        [OrderAtribute(1)]
        [DataAtribute]
        [FKeyAtribute(Table = "Context", Conection = CType.INNER)]
        [DBAtribute(hide: false, table: "Contexts", field: "idContext")]
        public int IdContext { get; set; }

        [OrderAtribute(2)]
        [DBAtribute(hide: false, table: "Context", field: "domen")]
        public string? Domen { get; set; }

        [OrderAtribute(3)]
        [DataAtribute]
        [FKeyAtribute(Table = "Contextable", Conection = CType.INNER)]
        [DBAtribute(hide: false, table: "Contexts", field: "idlearninghistroy")]
        public int IdContextable { get; set; }

        [FKeyAtribute(Table = "learninghistroy", Conection = CType.INNER)]
        [DBAtribute(hide: true, table: "Contextable", field: "idlearninghistroy")]
        public int IdLearning { get; set; }

        [OrderAtribute(4)]
        [DBAtribute(hide: false, table: "learninghistroy", field: "comment")]
        public string? Comment { get; set; }
    }
}
