using System;
using System.Net;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gos.Server.Atribute;
using System.IO;

namespace Gos.Server
{
    internal class Requester<T, F>:IDisposable where T : class where F : class
    {
        public string Url => _url;
        private string _url;
        private string route;
        public Requester (string url)
        {
            _url = url;
            using (var apiAtrib =
                typeof(T).GetCustomAttributes(typeof(API), true).Cast<API>().First())
            {
                if (apiAtrib == null)
                    throw new NullReferenceException("Not found api route");
                route = apiAtrib.APIRoute;
            }
        }
        public T[] Select()
        {
            var request = WebRequest.Create(_url +"/"+ route + "/Select");
            request.Method = "GET";
            using (var responde = new StreamReader(request.GetResponse().GetResponseStream()))
            {
                string json = responde.ReadToEnd();
                var result = JsonSerializer.Deserialize<T[]>(json);
                responde.Close();
                return result;
            }
        }
        public T[] Select(F filter)
        {
            var request = WebRequest.Create(_url + "/" + route + "/Select");
            request.Method = "POST";
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string filterJson = JsonSerializer.Serialize<F>(filter,options);
            var bytes = UnicodeEncoding.UTF8.GetBytes(filterJson);
            request.ContentLength = bytes.Length;
            request.ContentType = "application/json";
            using (var stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
            }
            using (var responde = new StreamReader(request.GetResponse().GetResponseStream()))
            {
                var result = JsonSerializer.Deserialize<T[]>(responde.ReadToEnd());
                responde.Close();
                return result;
            }
            
        }

        public string Insert(T table)
        {
            try
            {
                var request = WebRequest.Create(_url + "/" + route + "/Insert");
                request.Method = "POST";
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                string filterJson = JsonSerializer.Serialize<T>(table,options);
                var bytes = UnicodeEncoding.UTF8.GetBytes(filterJson);
                request.ContentLength = bytes.Length;
                request.ContentType = "application/json";
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Close();
                }
                using (var responde = new StreamReader(request.GetResponse().GetResponseStream()))
                {
                    var result = responde.ReadToEnd();
                    responde.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Update(T table)
        {
            try
            {
                var request = WebRequest.Create(_url + "/" + route + "/Update");
                request.Method = "POST";
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                string filterJson = JsonSerializer.Serialize<T>(table,options);
                var bytes = UnicodeEncoding.UTF8.GetBytes(filterJson);
                request.ContentLength = bytes.Length;
                request.ContentType = "application/json";
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Close();
                }
                using (var responde = new StreamReader(request.GetResponse().GetResponseStream()))
                {
                    var result = responde.ReadToEnd();
                    responde.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(T table)
        {
            try
            {
                var request = WebRequest.Create(_url + "/" + route + "/Delete");
                request.Method = "POST";
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                string filterJson = JsonSerializer.Serialize<T>(table,options);
                var bytes = UnicodeEncoding.UTF8.GetBytes(filterJson);
                request.ContentLength = bytes.Length;
                request.ContentType = "application/json";
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Close();
                }
                using (var responde = new StreamReader(request.GetResponse().GetResponseStream()))
                {
                    var result = responde.ReadToEnd();
                    responde.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public void Dispose()
        {
            
        }
    }
}
