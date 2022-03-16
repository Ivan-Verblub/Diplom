using Server.MySQL.Atributes.Filter;

namespace Server.MySQL.Tables
{
    public class LearningHistoryFilter
    {
        [FilterAtribute(field: "idlearninghistroy",
            table: "learninghistroy", filtType: FType.EQUAL)]
        public int Id { get; set; }

        [FilterAtribute(field: "date",
            table: "learninghistroy", filtType: FType.EQUAL)]
        public DateTime Date { get; set; }

        [RangeAtribute(0,0)]
        [FilterAtribute(field: "date",
            table: "learninghistroy", filtType: FType.GREATEREQUAL)]
        public DateTime DateBegin { get; set; }

        [RangeAtribute(0, 1)]
        [FilterAtribute(field: "date",
            table: "learninghistroy", filtType: FType.LESSEREQUAL)]
        public DateTime DateEnd { get; set; }

        [FilterAtribute(field: "iteration",
            table: "learninghistroy", filtType: FType.EQUAL)]
        public int iter { get; set; }

        [FilterAtribute(field: "iddataset",
            table: "learninghistroy", filtType: FType.EQUAL)]
        public int IdDataSet { get; set; }

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
    }
}
