using System;

namespace Gos.Server.Models.Filter
{
    public class ContextableFilter
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public DateTime DateG { get; set; }
        public DateTime DateL { get; set; }

        public int Iter { get; set; }
        public int IterG { get; set; }
        public int IterL { get; set; }

        public int IdDataSet { get; set; }

        public string SetName { get; set; }
        public string SetNameL { get; set; }

        public string Comment { get; set; }
        public string CommentL { get; set; }

        public string Version { get; set; }
        public string VersionL { get; set; }

        public int IdSearch { get; set; }
        public int IdSearchN { get; set; }

        public string SearchName { get; set; }
        public string SearchNameL { get; set; }
    }
}
