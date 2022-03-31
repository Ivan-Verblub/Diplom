using Microsoft.AspNetCore.Mvc;
using Server.Controllers.Models;
using Server.ML;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text;
using Server.MySQL;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : Controller
    {
        private StaticTables st = StaticTables.Instance;
        [HttpPost("DownloadUrl/{url}/{dataSet}")]
        public void DownloadUrl(string url, int dataSet)
        {
            string[] data = new string[0];
            if (url.Contains("mvideo"))
                data = MVideo(url);
            else if (url.Contains("dns-shop"))
                data = DNSShop(url);
            else
                data = Standart(url);
            foreach(var element in data)
            {
                st.DataT.Insert(new()
                {
                    Feature = element,
                    IdDataSet = dataSet
                });

            }
        }

        private string[] Standart(string url)
        {
            var chromeOptions = new ChromeOptions();
            using (var driver = new ChromeDriver(chromeOptions))
            {
                driver.Url = url;
                HtmlDocument doc = new HtmlDocument();
                string html = driver.FindElement(By.XPath("//body")).GetAttribute("innerHTML");
                doc.LoadHtml(html);
                doc.LoadHtml(FormatHtml(doc.DocumentNode.InnerHtml));
                return FormatText(doc.DocumentNode.InnerText);
            }
        }

        private string[] DNSShop(string url)
        {
            if (!url.Contains("/characteristics/"))
                url += "/characteristics/";
            var chromeOptions = new ChromeOptions();
            using (var driver = new ChromeDriver(chromeOptions))
            {
                driver.Url = url;
                HtmlDocument doc = new HtmlDocument();
                string html = driver.FindElement(By.XPath("//body")).GetAttribute("innerHTML");
                doc.LoadHtml(html);
                List<string> tags = new();
                tags.Add("a");
                tags.Add("#comment");
                doc = DeleteUnusedTags(doc, tags);
                doc.LoadHtml(FormatHtml(doc.DocumentNode.InnerHtml));
                return FormatText(doc.DocumentNode.InnerText);
            }
        }

        private string[] MVideo(string url)
        {
            if (!url.Contains("specification"))
                url += "/specification";
            var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments("headless");
            using (var driver = new ChromeDriver(chromeOptions))
            {
                driver.Url = url;
                HtmlDocument doc = new HtmlDocument();
                string html = driver.FindElement(By.XPath("//body")).GetAttribute("innerHTML");
                doc.LoadHtml(html);
                List<string> tags = new();
                tags.Add("span");
                tags.Add("#comment");
                doc = DeleteUnusedTags(doc, tags);
                doc.LoadHtml(FormatHtml(doc.DocumentNode.InnerHtml));
                return FormatText(doc.DocumentNode.InnerText);
            }
            
        }
        private HtmlDocument DeleteUnusedTags(HtmlDocument doc, List<string> tags)
        {
            HtmlNodeCollection tryGetNodes = doc.DocumentNode.SelectNodes("./*|./text()|./comment()");
            var nodes = new Queue<HtmlNode>(tryGetNodes);

            while (nodes.Count > 0)
            {
                var node = nodes.Dequeue();
                var parentNode = node.ParentNode;
                var childNodes = node.SelectNodes("./*|./text()|./comment()");

                if (childNodes != null)
                {
                    foreach (var child in childNodes)
                    {
                        nodes.Enqueue(child);
                    }
                }
                if (tags.Any(tag => tag == node.Name))
                {
                    if (childNodes != null)
                    {
                        foreach (var child in childNodes)
                        {
                            parentNode.InsertBefore(child, node);
                        }
                    }

                    parentNode.RemoveChild(node);

                }
            }
            return doc;
        }
        private string FormatHtml(string html)
        {
            StringBuilder builder = new();
            foreach(var element in html)
            {
                if(element != '\n')
                    builder.Append(element);
            }

            StringBuilder builder2 = new();
            foreach (var element in builder.ToString())
            {
                builder2.Append(element);
                if(element == '>')
                    builder2.Append('\n');
            }
            return builder2.ToString();
        }
        private string[] FormatText(string text)
        {
            List<string> data = new(text.Split('\n'));
            List<string> nData = new();
            foreach (var d in data)
            {
                string nd = d;
                nd = nd.Trim();
                while (nd.Contains("\r"))
                    nd = nd.Replace("\r", "");
                while (nd.Contains("\t"))
                    nd = nd.Replace("\t", "");
                while (nd.Contains("&nbsp;"))
                    nd = nd.Replace("&nbsp;", "");
                
                nData.Add(nd);
            }
            while (nData.Remove(nData.Find(s => String.IsNullOrWhiteSpace(s)))) { }
            return nData.ToArray();
        }
    }
}
