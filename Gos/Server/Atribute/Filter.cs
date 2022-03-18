using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gos.Server.Atribute
{
    [System.AttributeUsage(AttributeTargets.Property
        , AllowMultiple = true)]
    internal class Filter : Attribute, IDisposable
    {
        public Filtration Filt => _filt;
        private Filtration _filt;

        public Filter(Filtration filt)
        {
            _filt = filt;
        }

        public void Dispose()
        {
        }
    }
}
