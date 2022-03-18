using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gos.Server.Atribute
{
    [System.AttributeUsage(AttributeTargets.Field
        | AttributeTargets.Property | AttributeTargets.Property
        , AllowMultiple = true)]
    internal class API : Attribute
    {
        public string APIRoute { get; set; }
    }
}
