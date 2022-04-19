using Gos.Server.Atribute;

namespace Gos.Server.Models.Table
{
    [API("Tables/DataSet")]
    [Updateable]
    [Insertable]
    [Deleteable]
    public class DataSet
    {
        [Localize("Код")]
        [Key(true)]
        [AI]
        [Invisible]
        public int? idDataSet { get; set; }

        [Localize("Название сета")]
        [Key(false)]
        public string setName { get; set; }

    }
}
