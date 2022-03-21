using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gos.Server.Atribute
{
    [System.AttributeUsage(AttributeTargets.Property
        , AllowMultiple = true)]
    internal class Typeable : Attribute, IDisposable
    {
        public Type FType => _fType;
        private Type _fType;
        public Type TType => _tType;
        private Type _tType;

        public Typeable(Type fType, Type tType)
        {
            _fType = fType;
            _tType = tType;
        }

        public void Dispose()
        {
        }
    }
}
