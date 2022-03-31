using Server.MySQL.Atributes.Filter;

namespace Server.MySQL.Tables.Filter
{
    public class ActualFilter
    {
        [FilterAtribute(field: "idactual",
            table: "actual", filtType: FType.EQUAL)]
        public int IdActual { get; set; }

        [FilterAtribute(field: "name",
            table: "actual", filtType: FType.EQUAL)]
        public string? Name { get; set; }

        [FilterAtribute(field: "name",
            table: "actual", filtType: FType.LIKE)]
        public string? NameL { get; set; }

        [FilterAtribute(field: "idlearninghistroy",
            table: "actual", filtType: FType.EQUAL)]
        public int IdLearn { get; set; }

        [FilterAtribute(field: "comment",
            table: "learninghistroy", filtType: FType.EQUAL)]
        public string? Comment { get; set; }

        [FilterAtribute(field: "comment",
            table: "learninghistroy", filtType: FType.LIKE)]
        public string? CommentL { get; set; }

        [FilterAtribute(field: "version",
            table: "learninghistroy", filtType: FType.EQUAL)]
        public string? Version { get; set; }

        [FilterAtribute(field: "version",
            table: "learninghistroy", filtType: FType.LIKE)]
        public string? VersionL { get; set; }

        [FilterAtribute(field: "type",
            table: "actual", filtType: FType.EQUAL)]
        public int Types { get; set; }
    }
}
