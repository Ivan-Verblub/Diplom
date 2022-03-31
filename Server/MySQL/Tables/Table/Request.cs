using Server.MySQL.Atributes;
using Server.MySQL.Atributes.Table;

namespace Server.MySQL.Tables.Table
{
    [TableAtribute(new string[] { "request", "learninghistroy" })]
    public class Request
    {
        [OrderAtribute(0)]
        [KeyAtribute(ai:true)]
        [DBAtribute(hide: false, table: "request", field:"idrequest")]
        public int Id { get; set; }

        [DataAtribute]
        [OrderAtribute(1)]
        [DBAtribute(hide: false, table: "request", field: "name")]
        public string? Name { get; set; }

        [ByteArray]
        [OrderAtribute(2)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "request", field: "File")]
        public string? File { get; set; }

        [OrderAtribute(3)]
        [DataAtribute]
        [FKeyAtribute(table: "learninghistroy", conection: CType.INNER)]
        [DBAtribute(hide: false, table: "request", field: "idlearninghistroy")]
        public int IdLearning { get; set; }

        [OrderAtribute(4)]
        [DBAtribute(hide: false, table: "learninghistroy", field: "comment")]
        public string? Comment { get; set; }
    }
}
