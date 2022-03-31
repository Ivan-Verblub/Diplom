using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gos.Server.Atribute
{
    [System.AttributeUsage(AttributeTargets.Property
       , AllowMultiple = true)]
    internal class Invisible : Attribute, IDisposable
    {
        public void Dispose()
        {
        }
    }
}
