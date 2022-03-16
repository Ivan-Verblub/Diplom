using Server.MySQL.Atributes.Filter;

namespace Server.MySQL.Tables.Filter
{
    public class ContextsFilter
    {
        [FilterAtribute("idContexts", "Contexts",FType.EQUAL)]
        public int Id { get; set; }

        [FilterAtribute("idContext", "Contexts", FType.EQUAL)]
        public int IdContext { get; set; }

        [FilterAtribute("domen", "Context", FType.EQUAL)]
        public string? Domen { get; set; }
        [FilterAtribute("domen", "Context", FType.LIKE)]
        public string? DomenL { get; set; }

        [FilterAtribute("idlearninghistroy", "Contexts", FType.EQUAL)]
        public int IdContextable { get; set; }

        [FilterAtribute("comment", "Context", FType.EQUAL)]
        public string? Comment { get; set; }
        [FilterAtribute("comment", "Context", FType.LIKE)]
        public string? CommentL { get; set; }
    }
}
