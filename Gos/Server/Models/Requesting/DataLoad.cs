using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gos.Server.Models.Requesting
{
    class DataLoad
    {
        public string Url { get; set; }
        public int IdDataSet { get; set; }
        public int? IdContext { get; set; }
    }
}
