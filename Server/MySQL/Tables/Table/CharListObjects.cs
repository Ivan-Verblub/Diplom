using Server.MySQL.Atributes;

namespace Server.MySQL.Tables.Table
{
    [TableAtribute(new string[] { "CharListObjects", "objects" })]
    public class CharListObjects
    {
        [OrderAtribute(0)]
        [KeyAtribute(true)]
        [DBAtribute(hide: false, table: "CharListObjects", field: "idCharList")]
        public int? Id { get; set; }

        [OrderAtribute(1)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "CharListObjects", field: "Name")]
        public string? Name { get; set; }

        [OrderAtribute(2)]
        [DataAtribute]
        [DBAtribute(hide: false, table: "CharListObjects", field: "Value")]
        public string? Value { get; set; }

        [OrderAtribute(3)]
        [DataAtribute]
        [FKeyAtribute(Conection = CType.INNER, Table = "objects")]
        [DBAtribute(hide: false, table: "CharListObjects", field: "invnumber")]
        public string? IdObject { get; set; }

        [OrderAtribute(4)]
        [DBAtribute(hide: false, table: "objects", field: "name")]
        public string? ObjectName { get; set; }
    }
}
