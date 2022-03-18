using System;

namespace Gos.Server.Models.Filter
{
    public class LearningHistoryFilter
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public DateTime DateBegin { get; set; }

        public DateTime DateEnd { get; set; }

        public int iter { get; set; }

        public int IdDataSet { get; set; }

        public string Comment { get; set; }

        public string CommentL { get; set; }

        public string Version { get; set; }

        public string VersionL { get; set; }
    }
}
