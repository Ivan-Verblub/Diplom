using System;
using System.Net;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gos.Server
{
    internal class Requester<T, F>:IDisposable where T : class where F : class
    {
        public string Url => _url;
        private string _url;
        public Requester (string url)
        {
            _url = url;
        }
        public T[] Select()
        {
            //typeof(T).GetCustomAttributes<>();

            return null;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
