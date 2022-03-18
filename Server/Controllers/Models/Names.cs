namespace Server.Controllers.Models
{
    public class Names
    {
        public int Id { get; set; }
        public int IdAct { get; set; }
        public int[]? ContextId { get; set; }
        public SOptions?[]? Option { get; set; }
    }
}
