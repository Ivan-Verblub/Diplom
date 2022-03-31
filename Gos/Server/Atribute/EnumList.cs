using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gos.Server.Atribute
{
    [AttributeUsage(AttributeTargets.Property,
        AllowMultiple = true)]
    internal class EnumList: Attribute, IDisposable
    {
        public Type EnumType => _enumType;
        private Type _enumType;

        public EnumList(Type enumType)
        {
            _enumType = enumType;
        }

        public void Dispose()
        {
        }
    }
}
