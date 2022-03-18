﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gos.Server.Atribute
{
    [System.AttributeUsage(AttributeTargets.Class
        , AllowMultiple = true)]
    internal class API : Attribute, IDisposable
    {
        public string APIRoute => _apiRoute;
        private string _apiRoute;

        public API(string apiRoute)
        { 
            _apiRoute = apiRoute;
        }

        public void Dispose()
        {
        }
    }
}
