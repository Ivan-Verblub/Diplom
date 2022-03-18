using System;

namespace Gos.Server.Models.Filter
{
    public class ObjectsHistoryFilter
    {
        public int Id { get; set; }

        public string InvNumber { get; set; }

        public string InvNumberL { get; set; }

        public string Name { get; set; }

        public string NameL { get; set; }

        public int IdStatus { get; set; }

        public string Status { get; set; }

        public string StatusL { get; set; }

        public int IdLocation { get; set; }

        public string Location { get; set; }

        public string LocationL { get; set; }

        public DateTime Date { get; set; }

        public DateTime DateG { get; set; }

        public DateTime DateL { get; set; }

        public string Comment { get; set; }

        public string CommentL { get; set; }
    }
}
