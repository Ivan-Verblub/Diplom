using Gos.Server.Atribute;

namespace Gos.Server.Models.Table
{
    [API("Tables/SStatus")]
    [Updateable]
    [Insertable]
    [Deleteable]
    public class SStatus
    {
        [Localize("Код")]
        [AI]
        [Key(true)]
        [Invisible]
        public int? idStatus { get; set; }
        [Localize("Название статуса")]
        [Key(false)]
        public string status { get; set; }
    }
}
