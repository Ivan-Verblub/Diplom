using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gos.Server.Models.Requesting
{
    public class Final
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public int Cost { get; set; }
        public List<About> Abouts {get;set;}
    }
}
