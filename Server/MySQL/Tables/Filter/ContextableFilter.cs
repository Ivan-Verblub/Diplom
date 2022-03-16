using Server.MySQL.Atributes.Filter;

namespace Server.MySQL.Tables.Filter
{
    public class ContextableFilter
    {
        [FilterAtribute("idlearninghistroy", "Contextable",FType.EQUAL)]
        public int Id { get; set; }

        [FilterAtribute("date", "learninghistroy", FType.EQUAL)]
        public DateTime Date { get; set; }
        [FilterAtribute("date", "learninghistroy", FType.GREATEREQUAL)]
        public DateTime DateG { get; set; }
        [FilterAtribute("date", "learninghistroy", FType.LESSEREQUAL)]
        public DateTime DateL { get; set; }

        [FilterAtribute("iteration", "learninghistroy", FType.EQUAL)]
        public int Iter { get; set; }
        [FilterAtribute("iteration", "learninghistroy", FType.GREATEREQUAL)]
        public int IterG { get; set; }
        [FilterAtribute("iteration", "learninghistroy", FType.LESSEREQUAL)]
        public int IterL { get; set; }

        [FilterAtribute("iddataset", "learninghistroy", FType.EQUAL)]
        public int IdDataSet { get; set; }

        [FilterAtribute("setName", "dataset", FType.EQUAL)]
        public string? SetName { get; set; }
        [FilterAtribute("setName", "dataset", FType.LIKE)]
        public string? SetNameL { get; set; }

        [FilterAtribute("comment", "learninghistroy", FType.EQUAL)]
        public string? Comment { get; set; }
        [FilterAtribute("comment", "learninghistroy", FType.LIKE)]
        public string? CommentL { get; set; }

        [FilterAtribute("version", "learninghistroy", FType.EQUAL)]
        public string? Version { get; set; }
        [FilterAtribute("version", "learninghistroy", FType.LIKE)]
        public string? VersionL { get; set; }

        [FilterAtribute("idSearchContext", "Contextable", FType.EQUAL)]
        public int IdSearch { get; set; }
        [FilterAtribute("idSearchContext", "Contextable", FType.ISNULL)]
        public int IdSearchN { get; set; }

        [FilterAtribute("name", "SearchContext", FType.EQUAL)]
        public string? SearchName { get; set; }
        [FilterAtribute("name", "SearchContext", FType.LIKE)]
        public string? SearchNameL { get; set; }
    }
}
