using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using Server.Controllers.Models;

namespace Server.Controllers.Tech
{
    [Route("[controller]")]
    [ApiController]
    public class TesterController : ControllerBase
    {
        [HttpPost("Catalog")]
        public bool TestC(PathC product, string link)
        {
            try
            {
                using (var driverInner = new EdgeDriver())
                {
                    driverInner.Url = link;
                    var elemensLink = driverInner.FindElements(
                            By.XPath(product.Cell));
                    var elemensNames = driverInner.FindElements(
                            By.XPath(product.CellName));
                    for (int i = 0; i<elemensLink.Count; i++)
                    {
                        elemensLink[i].GetDomProperty("href");
                    }
                    var next = driverInner.FindElement(
                        By.XPath(product.Next));
                    try
                    {
                        next.Click();
                    }
                    catch
                    {

                    }
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
        [HttpPost("Product")]
        public bool TestP(PathP product, string link)
        {
            try
            {
                using (var driverInner = new EdgeDriver())
                {
                    driverInner.Url = link;
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(driverInner.FindElement(By.XPath("//body"))
                        .GetAttribute("outerHTML"));
                    var tableNode = doc.DocumentNode.SelectNodes(product.Table)[0];
                    var rows = tableNode.SelectNodes(product.Row);
                    foreach (var item in rows)
                    {
                        var local = HtmlNode.CreateNode(item.OuterHtml);
                        local.SelectNodes(product.Title);
                        local.SelectNodes(product.Value);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
