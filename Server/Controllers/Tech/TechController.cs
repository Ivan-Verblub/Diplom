using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Server.Controllers.Models;
using Server.ML;
using Server.MySQL;
using Server.MySQL.Tables.Filter;
using System.Data;
using System.Web;

namespace Server.Controllers.Tech
{
    [Route("[controller]")]
    [ApiController]
    public class TechController : ControllerBase
    {
        private const int count = 5;
        private StaticTables st = StaticTables.Instance;
        private ML.ML ml;
        private Names? names;
        [HttpPost("Select")]
        public Models.Char[] Select(Names n)
        {
            this.names = n;
            var filter = new SearchNamesFilter();
            filter.IdSearch = n.Id;
            var names = st.SearchNamesT.Select(filter);
            ml = new ML.ML(0);
            var fAct = new ActualFilter()
            {
                IdActual = n.IdAct,
            };
            var dt = st.ActualT.Select(fAct); 
            ml.Load(dt.Rows[0].Field<byte[]>("conf"));
            Models.Char[] chars= new Models.Char[1];
            foreach(var name in names.Select())
            {
                foreach (var option in n.Option)
                {
                    if(name.Field<int>("idSearchNames") == option.Id)
                    {
                        chars = Search(option);
                    }
                }
            }
            return chars;
        }

        //Дополни не контекстным поиском, кинь срань, которая рабоать не будет)))00)00
        private Models.Char[] Search(SOptions op)
        {
            List<Models.Char> result = new List<Models.Char>();
            foreach (var context in names.ContextId)
            {
                var filter = new ContextFilter()
                {
                    Id = context
                };
                var dt = st.ContextT.Select(filter);

                var sFilter = new SearchNamesFilter()
                {
                    IdSearch = op.Id
                };
                var sdt = st.SearchNamesT.Select(sFilter);

                UriBuilder builder = new UriBuilder();
                builder.Host = "google.com";
                string query = 
                    HttpUtility.UrlEncode($"{sdt.Rows[0].Field<string>("name")} " +
                    $"{op.Option} site: {dt.Rows[0].Field<string>("Domen")}");
                builder.Query = $"search?q={query}";

                List<string> links = new List<string>();
                var chromeOptions = new ChromeOptions();
                using (var driver = new ChromeDriver(chromeOptions))
                {
                    driver.Url = builder.ToString();
                    var html = driver.FindElements(By.XPath("//div[@class = \"g tF2Cxc\"]"));
                    for (int i = 0; i <
                        ((count > html.Count)? html.Count : count); i++)
                        foreach (var element in html)
                        {
                            driver.Url = Parse(element.GetAttribute("outerHTML"));
                            string? link = Link(driver.Url,context);
                            if (link != null)
                                links.Add(link);
                        }

                    foreach (var item in links)
                    {
                        driver.Url = item;
                        var chars = 
                            ContextableSearch(driver.FindElement(By.XPath("//body")).Text,0);
                        result.AddRange(chars);
                    }
                }
                foreach (var res in result)
                {
                    Data data = new()
                    {
                        Feature = res.Value + "\n" + res.Name
                    };
                    var pretiction = ml.Predcit(data);
                    //При обучении измени строку
                    if (pretiction.PredictedLabel == "")
                        result.Remove(res);
                }
            }
            return result.ToArray();
        }
        private string? Link(string link, int context)
        {
            string? newLink = "";
            var filter = new OptionsFilter()
            {
                IdContext = context,
                Type = (int)OpType.LINKISAVAILIBLE
            };
            var dt = st.OptionsT.Select(filter);
            if (dt.Rows.Count != 0)
            {
                if (link.Contains(dt.Rows[0].Field<string>("value")))
                    return null;
            }

            filter.Type = (int)OpType.LINKFORMAT;
            dt = st.OptionsT.Select(filter);
            if (dt.Rows.Count != 0)
            {
                var elements = link.Split('/');
                int count = int.Parse(dt.Rows[0].Field<string>("value"));
                newLink = String.Join('/', elements.Take(count));
            }

            filter.Type = (int)OpType.LINKADD;
            dt = st.OptionsT.Select(filter);
            if (dt.Rows.Count != 0)
            {
                if (newLink == "")
                    newLink = link;
                newLink += $"/{dt.Rows[0].Field<string>("value")}";
            }

            return newLink;
        }
        private string Parse(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            return GetLink(doc.DocumentNode);
        }
        private Models.Char[] ContextableSearch(string html, int idContext)
        {
            List<Models.Char> chars = new List<Models.Char>();
            var opF = new OptionsFilter()
            {
                IdContext = idContext
            };
            
            var res = st.OptionsT.Select(opF);
            foreach(DataRow row in res.Rows)
            {
                switch ((OpType)row.Field<int>("type"))
                {
                    case OpType.REMOVE:
                        html.Replace(row.Field<string>("value"),"");
                        break;
                }

            }

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            var pathF = new PathsFilter()
            {
                IdContext = idContext,
                Type = (int)PathType.TABLE
            };
            var path = st.PathsT.Select(pathF);
            var tableNode = doc.DocumentNode.SelectNodes(path.Rows[0].Field<string?>("Path"))[0];

            pathF.Type = (int)PathType.ROW;
            path = st.PathsT.Select(pathF);
            string? rowPath = path.Rows[0].Field<string?>("Path");
            var rows = tableNode.SelectNodes(rowPath);

            pathF.Type = (int)PathType.COLUMNVALUE;
            path = st.PathsT.Select(pathF);
            string? columnVPath = path.Rows[0].Field<string?>("Path");

            pathF.Type = (int)PathType.COLUMNTITLE;
            path = st.PathsT.Select(pathF);
            string? columnTPath = path.Rows[0].Field<string?>("Path");

            foreach (var item in rows)
            {
                chars.Add(new Models.Char() {
                    Name = item.SelectNodes(columnTPath)[0].InnerText,
                    Value = item.SelectNodes(columnVPath)[0].InnerText
                });
            }

            return chars.ToArray();

        }

        private string GetLink(HtmlNode node)
        {
            if (node.Element("a") == null)
                return GetLink(node.Element("div"));
            return node.Element("a").Attributes["href"].Value;
        }
    }
}
