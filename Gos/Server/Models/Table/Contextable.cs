using Gos.Server.Atribute;
using System;

namespace Gos.Server.Models.Table
{
    [API("Tables/Contextable")]
    public class Contextable
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Iter { get; set; }

        public int IdDataSet { get; set; }

        public string SetName { get; set; }

        public string Comment { get; set; }

        public string Version { get; set; }

        public int IdSearch { get; set; }

        public string SearchName { get; set; }
    }
}
