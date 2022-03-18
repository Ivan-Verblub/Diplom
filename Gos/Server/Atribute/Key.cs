using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gos.Server.Atribute
{
    [System.AttributeUsage(AttributeTargets.Property
        , AllowMultiple = true)]
    internal class Key : Attribute, IDisposable
    {
        public bool IsKey => _isKey;
        private bool _isKey;

        public Key(bool isKey)
        {
            _isKey = isKey;
        }

        public void Dispose()
        {
        }
    }
}
