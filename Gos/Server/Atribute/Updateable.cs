using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gos.Server.Atribute
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = true)]
    class Updateable: Attribute, IDisposable
    {
        public void Dispose()
        {
            
        }
    }
}
