using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Server.Controllers.Models;
using Server.MySQL;
using Server.MySQL.Tables.Filter;
using System.Data;
using System.Web;

namespace Server.Controllers.Tech
{
    [Route("UUUUU/[controller]")]
    [ApiController]
    public class TechiController : ControllerBase
    {
        private const int count = 5;
        private StaticTables st = StaticTables.Instance;
        [HttpPost("UUUUU")]
        public void Select(Names n)
        {
            var filter = new SearchNamesFilter();
            filter.IdSearch = n.Id;
            var names = st.SearchNamesT.Select(filter);
            foreach(var name in names.Select())
            {
                foreach (var ns in n.Option)
                {
                    if(name.Field<int>("idSearchNames") == ns.Id)
                    {
                        Search(ns,n.ContextId);
                    }
                }
            }
        }

        private Models.Char[] Search(SOptions op, int[] contexts)
        {
            foreach (var context in contexts)
            {
                var filter = new ContextFilter()
                {
                    Id = context
                };
                var dt = st.ContextT.Select(filter);
                UriBuilder builder = new UriBuilder();
                builder.Host = "google.com";
                builder.Query = $"search?q=" +
                    $"{HttpUtility.UrlEncode("")}";
                string url = builder.ToString();
                List<string> links = new List<string>();
                var chromeOptions = new ChromeOptions();
                using (var driver = new ChromeDriver(chromeOptions))
                {
                    driver.Url = url;
                    var html = driver.FindElements(By.XPath("//div[@class = \"g tF2Cxc\"]"));
                    for (int i = 0; i < count; i++)
                        foreach (var element in html)
                        {
                            links.Add(Parse(element.GetAttribute("outerHTML")));
                        }

                    foreach (var item in links)
                    {
                        driver.Url = item;
                        ContextableSearch(driver.FindElement(By.XPath("//body")).Text,0);
                    }
                }
            }
            return null;
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
                    case OpType.CLEAR:
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
