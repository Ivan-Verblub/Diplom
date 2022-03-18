using Gos.Server.Atribute;
using System;

namespace Gos.Server.Models.Table
{
    [API("Tables/ObjectsHistory")]
    public class ObjectsHistory
    {
        public int Id { get; set; }

        public string InvNumber { get; set; }

        public string Name { get; set; }

        public int IdStatus { get; set; }

        public string Status { get; set; }

        public int IdLocation { get; set; }

        public string Location { get; set; }

        public DateTime Date { get; set; }

        public string comment { get; set; }
    }
}
