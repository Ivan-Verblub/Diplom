using Server.MySQL.Atributes.Filter;

namespace Server.MySQL.Tables.Filter
{
    public class RequestFilter
    {
        [FilterAtribute(field: "idrequest",
            table: "request", filtType: FType.EQUAL)]
        public int Id { get; set; }

        [FilterAtribute(field: "name",
            table: "request", filtType: FType.EQUAL)]
        public string? Name { get; set; }

        [FilterAtribute(field: "idrequest",
            table: "request", filtType: FType.EQUAL)]
        public string? NameL { get; set; }

        [FilterAtribute(field: "idlearninghistroy",
            table: "request", filtType: FType.EQUAL)]
        public int IdLearning { get; set; }

        [FilterAtribute(field: "comment",
            table: "learninghistroy", filtType: FType.EQUAL)]
        public string? Comment { get; set; }

        [FilterAtribute(field: "comment",
            table: "learninghistroy", filtType: FType.EQUAL)]
        public string? CommentL { get; set; }
    }
}
