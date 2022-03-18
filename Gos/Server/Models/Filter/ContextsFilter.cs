namespace Gos.Server.Models.Filter
{
    public class ContextsFilter
    {
        public int Id { get; set; }

        public int IdContext { get; set; }

        public string Domen { get; set; }
        public string DomenL { get; set; }

        public int IdContextable { get; set; }

        public string Comment { get; set; }
        public string CommentL { get; set; }
    }
}
