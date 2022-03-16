using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using HtmlAgilityPack;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Diagnostics;

namespace ConsoleApp4
{
    class Program
    {
        private const string url = @"https://www.mvideo.ru/products/igrovaya-klaviatura-red-square-keyrox-tkl-classic-rsq-20018-50141065/specification";
        private static string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"text.txt");
        private const string file = @"C:\Users\limcm\OneDrive\Рабочий стол\SlimeRancher-2022-01-06-08-38-07-11.png";
        static void Main(string[] args)
        {
            //var bytes = File.ReadAllBytes(file);
            //string str = Encoding.UTF8.GetString(bytes);
            //var b = Encoding.UTF8.GetBytes(str);
            //File.WriteAllText("p.png",str);
            //Process.Start("p.png");
            //Load();
            ML ml = new ML();  
        }
        
        static void Load()
        {
            var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments("headless");
            using (var driver = new ChromeDriver(chromeOptions))
            {
                driver.Url = url;
                HtmlDocument doc = new HtmlDocument();
                string html = driver.FindElement(By.XPath("//body")).GetAttribute("innerHTML");
                int i = 0;
                while (html.IndexOf("\n") >= 0)
                {
                    html = html.Replace("\n", "");
                }

                while (html.IndexOf(">",i) >= 0)
                {
                    html = html.Insert(html.IndexOf(">", i) + 1, "\n");
                    i = html.LastIndexOf(">\n") + 2;
                }
                doc.LoadHtml(html);
                Console.WriteLine("CODE\n");
                
                List<string> data = new List<string>(doc.DocumentNode.InnerText.Replace("\t", "").Split(Convert.ToChar("\n")));
                while (data.Remove(data.Find(s => String.IsNullOrWhiteSpace(s)))) { }
                while (data.Remove(data.Find(s => s == "\r"))) { }
                while (data.Remove(data.Find(s => s == " "))) { }
                data.ForEach(d => d = d.Trim());
                MySqlConnection c = new MySqlConnection("Data Source = localhost; DataBase = testing; " +
                    "user = root; password = qwerty; charset = utf8");
                MySqlCommand cm = new MySqlCommand();
                cm.Connection = c;
                c.Open();
                string query = "INSERT INTO data(data) VALUES ";
                query += $"('{String.Join("\n",data)}')";
                //data.ForEach(d => query += $"('{d}'),\n ");
                cm.CommandText = query;
                cm.ExecuteNonQuery();
                c.Close();
            }
            //WebClient client = new WebClient();
            //CookieContainer cookieContainer = new CookieContainer();
            //cookieContainer.Add(new Cookie(@"ipp_key",@"v1641819584530/v3394bd400b5e53a13cfc65163beca2afa04ab3/lEA2/6uRViOFPZ1M73YhCw==","/", "dns-shop.ru"));
            //cookieContainer.Add(new Cookie(@"ipp_uid", @"1641831336967/6pIt1AaELqmAwaw3/lRy0NRjX7E42mBujw0xuvw==", "/", "dns-shop.ru"));
            //client.Headers.Add(@"X-Requested-With", @"XMLHttpRequest");
            //client.Headers.Add(@"User-Agent", @"Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:70.0) Gecko/20100101 Firefox/70.0");
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.Method = "GET";
            //request.Headers.Add(@"X-Requested-With", @"XMLHttpRequest");
            //request.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:70.0) Gecko/20100101 Firefox/70.0";
            //request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
            //request.Host = "www.dns-shop.ru";
            //request.CookieContainer = cookieContainer;
            //request.Headers.Add("Server", @"Variti/0.9.3a");
            //request.Headers.Add("X-Request-Id","aFQSrPHVMa61");
            //StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream());
            //while (client == null)
            //{
            //    Console.WriteLine("Trying..");
            //    client = CloudflareEvader.CreateBypassedWebClient("https://www.alphacomp.ru");
            //}
            //Console.WriteLine(client.DownloadString(url));
            //HtmlWeb web = new HtmlWeb();
            //HtmlDocument doc = web.Load(url);
            //List<string> data = new List<string>(doc.DocumentNode.InnerText.Replace("\t", "").Split(Convert.ToChar("\n")));
            //while (data.Remove(data.Find(s => String.IsNullOrWhiteSpace(s)))) { }
            //while (data.Remove(data.Find(s => s == "\r"))) { }
            //data.ForEach(d => d.Trim());
            //File.WriteAllText(path,reader.ReadToEnd());
            //MySqlConnection c = new MySqlConnection("Data Source = localhost; DataBase = testing; " +
            //    "user = root; password = qwerty; charset = utf8");
            //MySqlCommand cm = new MySqlCommand();
            //cm.Connection = c;
            //c.Open();
            //string query = "INSERT INTO data(iddata,data) VALUES ";
            //data.ForEach(d => query += $"(null,'{d}'),\n ");
            //cm.CommandText = query.Remove(query.LastIndexOf(','));
            //cm.ExecuteNonQuery();
            //c.Close();
        }
    }
}
