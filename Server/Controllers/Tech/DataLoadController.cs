using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using Server.Controllers.Models;
using Server.MySQL;
using Server.MySQL.Tables.Filter;
using Server.MySQL.Tables.Table;
using System.Data;
using System.Xml.XPath;

namespace Server.Controllers.Tech
{
    [Route("Tech/[controller]")]
    [ApiController]
    public class DataLoadController : ControllerBase
    {

        StaticTables st = StaticTables.Instance;
        [HttpPost("SetData")]
        public void SetData(DataLoad load)
        {
            if (load.IdContext == null)
                Noncontextable(load);
            else
                Contextable(load);
        }

        private void Contextable(DataLoad load)
        {
            var options = new EdgeOptions();
            string html = "";
            using (var driver = new EdgeDriver(options))
            {
                driver.Url = load.Url;
                html = driver.FindElement(By.XPath("//body")).GetAttribute("innerHTML");
            }

            var opF = new OptionsFilter()
            {
                IdContext = (int)load.IdContext
            };
            var res = st.OptionsT.Select(opF);
            foreach (DataRow row in res.Rows)
            {
                switch ((OpType)row.Field<int>("type"))
                {
                    case OpType.REMOVE:
                        html = html.Replace(row.Field<string>("value"), "");
                        break;
                }

            }

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            var pathF = new PathsFilter()
            {
                IdContext = (int)load.IdContext,
                Type = (int)PathType.TABLE
            };
            var path = st.PathsT.Select(pathF);
            var tableNode = doc.DocumentNode.SelectNodes(path.Rows[0].Field<string?>("Path"))[0];

            pathF.Type = (int)PathType.ROW;
            path = st.PathsT.Select(pathF);
            string? rowPath = path.Rows[0].Field<string?>("Path");
            var rows = HtmlNode.CreateNode(tableNode.OuterHtml).SelectNodes(rowPath);

            pathF.Type = (int)PathType.COLUMNVALUE;
            path = st.PathsT.Select(pathF);
            string? columnVPath = path.Rows[0].Field<string?>("Path");

            pathF.Type = (int)PathType.COLUMNTITLE;
            path = st.PathsT.Select(pathF);
            string? columnTPath = path.Rows[0].Field<string?>("Path");



            foreach (var item in rows)
            {
                var local = HtmlNode.CreateNode(item.OuterHtml);
                var dtT = new DatasTable()
                {
                    Feature = local.SelectNodes(columnTPath)[0].InnerText+
                    ";"+local.SelectNodes(columnVPath)[0].InnerText,
                    IdDataSet = load.IdDataSet
                };
                st.DataT.Insert(dtT);
            }
        }

        private void Noncontextable(DataLoad load)
        {
            var options = new EdgeOptions();
            string html = "";
            using (var driver = new EdgeDriver(options))
            {
                driver.Url = load.Url;
                html = driver.FindElement(By.XPath("//body")).Text;
            }
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            doc.DocumentNode.Descendants()
                .Where(n => n.NodeType == HtmlAgilityPack.HtmlNodeType.Comment)
                .ToList()
                .ForEach(n => n.Remove());
            string htmls = doc.DocumentNode.OuterHtml;
            htmls = htmls.Replace("\n", "");
            htmls = htmls.Replace("\r", "");
            string final = "";
            foreach(var let in htmls)
            {
                final += let;
                if (let == '>')
                    final += "\n";
            }
            doc.LoadHtml(final);
            var strings = doc.DocumentNode.InnerText;
            foreach(var s in strings.Split('\n'))
            {
                var dt = new DatasTable()
                {
                    Feature = s,
                    IdDataSet = load.IdDataSet
                };
                st.DataT.Insert(dt);
            }
        }
    }
}
