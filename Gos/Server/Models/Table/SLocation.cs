using Gos.Server.Atribute;

namespace Gos.Server.Models.Table
{
    [API("Tables/SLocation")]
    [Updateable]
    [Insertable]
    [Deleteable]
    public class SLocation
    {
        [Localize("Код")]
        [Key(true)]
        [AI]
        [Invisible]
        public int? idLocation { get; set; }

        [Localize("Расположение")]
        [Key(false)]
        public string location { get; set; }
    }
}
