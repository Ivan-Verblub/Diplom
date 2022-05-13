using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gos.Server.Atribute
{
    [System.AttributeUsage(AttributeTargets.Property |
        AttributeTargets.Field 
        , AllowMultiple = true)]
    internal class Localize : Attribute, IDisposable
    {
        public string Name => _name;
        private string _name;

        public Localize(string name)
        {
            _name = name;
        }

        public void Dispose()
        {
        }

    }
}
