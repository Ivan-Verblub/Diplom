using Gos.Server.Atribute;

namespace Gos.Server.Models.Table
{
    [API("Tables/SStatus")]
    public class SStatus
    {
        public int IdStatus { get; set; }

        public string Status { get; set; }
    }
}
