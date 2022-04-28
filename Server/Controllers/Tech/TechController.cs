using FuzzySharp;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using Server.Controllers.Models;
using Server.ML;
using Server.MySQL;
using Server.MySQL.Tables;
using Server.MySQL.Tables.Filter;
using System.Data;
using System.Text;
using System.Web;

namespace Server.Controllers.Tech
{
    [Route("Tech/[controller]")]
    [ApiController]
    public class TechController : ControllerBase
    {
        private static Models.Char[] _chars = null;
        private static bool isBusy = false;
        private const int count = 5;
        private StaticTables st = StaticTables.Instance;
        private ML.ML ml = ML.ML.Instance;
        private Names? names;

        [HttpPost("Select/{id}")]
        public ActionResult<Models.Char[]> TrySelect(int id, SOptions[] ops)
        {
            try
            {
                if (isBusy)
                {
                    return StatusCode(StatusCodes.Status502BadGateway);
                }
                else
                {
                    if (_chars != null)
                    {
                        var buff = _chars;
                        _chars = null;
                        return CreatedAtAction(null, buff);
                    }
                    else
                    {
                        Task.Run(() => { Select(id, ops);}) ;
                        return StatusCode(StatusCodes.Status502BadGateway);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private void Select(int id, SOptions[] ops)
        {
            isBusy = true;
            _chars = null;
            var na = new Names();
            var contextableF = new ContextableFilter()
            {
                Id = id
            };
            var cont = st.ContextableT.Select(contextableF);
            na.Id = cont.Select()[0].Field<int>("idSearchContext");
            na.Option = ops;
            var actF = new ActualFilter()
            {
                IdLearn = id
            };
            var act = st.ActualT.Select(actF);
            na.IdAct = act.Select()[0].Field<int>("idactual");
            List<int> contexts = new();
            var contsF = new ContextsFilter()
            {
                IdContextable = id
            };
            foreach (var item in st.ContextsT.Select(contsF).Select())
            {
                contexts.Add(item.Field<int>("idContext"));
            }
            na.ContextId = contexts.ToArray();

            this.names = na;
            var filter = new SearchNamesFilter();
            filter.IdSearch = this.names.Id;
            var names = st.SearchNamesT.Select(filter);
            Models.Char[] chars = new Models.Char[1];
            foreach (var name in names.Select())
            {
                foreach (var option in this.names.Option)
                {
                    if (name.Field<int>("idSearchNames") == option.Id)
                    {
                        chars = Search(ops.Where(x=>x.Id == name.Field<int>("idSearchNames")).ToArray());
                        break;
                    }
                }
            }
            isBusy = false;
            _chars = chars;
        }
        [HttpPost("Select/Link/{id}/{context}")]
        public ActionResult<Models.Char[]> TrySelectLink(int id, int context, string url)
        {
            try
            {
                if (isBusy)
                {
                    return StatusCode(StatusCodes.Status502BadGateway);
                }
                else
                {
                    if (_chars != null)
                    {
                        var buff = _chars;
                        _chars = null;
                        return CreatedAtAction(null, buff);
                    }
                    else
                    {
                        Task.Run(() => { SelectLink(id, context, url); });
                        return StatusCode(StatusCodes.Status502BadGateway);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private void SelectLink(int id,int context,string url)
        {
            isBusy = true;
            _chars = null;
            var na = new Names();
            var contextableF = new ContextableFilter()
            {
                Id = id
            };
            var cont = st.ContextableT.Select(contextableF);
            na.Id = cont.Select()[0].Field<int>("idSearchContext");
            var actF = new ActualFilter()
            {
                IdLearn = id
            };
            var act = st.ActualT.Select(actF);
            na.IdAct = act.Select()[0].Field<int>("idactual");
            List<int> contexts = new();
            var contsF = new ContextsFilter()
            {
                IdContextable = id
            };
            foreach (var item in st.ContextsT.Select(contsF).Select())
            {
                contexts.Add(item.Field<int>("idContext"));
            }
            this.names = na;
            var fAct = new ActualFilter()
            {
                IdActual = this.names.IdAct,
            };
            var dt = st.ActualT.Select(fAct);
            ml.Load(dt.Rows[0].Field<byte[]>("conf"));
            na.ContextId = contexts.ToArray();
            this.names = na;
            Models.Char[] chars;
            chars = GetCharsLink(context,url);
            isBusy = false;
            _chars = chars;
        }
        [HttpPost("Select/Name/{id}")]
        public ActionResult<Models.Char[]> TrySelectByName(int id, string name)
        {
            try
            {
                if (isBusy)
                {
                    return StatusCode(StatusCodes.Status502BadGateway);
                }
                else
                {
                    if (_chars != null)
                    {
                        var buff = _chars;
                        _chars = null;
                        return CreatedAtAction(null, buff);
                    }
                    else
                    {
                        Task.Run(() => { SelectByName(id, name); });
                        return StatusCode(StatusCodes.Status502BadGateway);
                    }
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private Models.Char[] SelectByName(int id,string name)
        {
            var na = new Names();
            var contextableF = new ContextableFilter()
            {
                Id = id
            };
            var cont = st.ContextableT.Select(contextableF);
            na.Id = cont.Select()[0].Field<int>("idSearchContext");
            var actF = new ActualFilter()
            {
                IdLearn = id
            };
            var act = st.ActualT.Select(actF);
            na.IdAct = act.Select()[0].Field<int>("idactual");
            List<int> contexts = new();
            var contsF = new ContextsFilter()
            {
                IdContextable = id
            };
            foreach (var item in st.ContextsT.Select(contsF).Select())
            {
                contexts.Add(item.Field<int>("idContext"));
            }
            na.ContextId = contexts.ToArray();

            this.names = na;
            var filter = new SearchNamesFilter();
            filter.IdSearch = this.names.Id;
            var names = st.SearchNamesT.Select(filter);
            var fAct = new ActualFilter()
            {
                IdActual = this.names.IdAct,
            };
            var dt = st.ActualT.Select(fAct);
            ml.Load(dt.Rows[0].Field<byte[]>("conf"));
            Models.Char[] chars;
            chars = GetCharsName(name);
            return chars;
        }

        private Models.Char[] GetCharsName(string name)
        {
            List<Models.Char> result = new List<Models.Char>();
            foreach (var context in names.ContextId)
            {
                var filter = new ContextFilter()
                {
                    Id = context
                };
                var dt = st.ContextT.Select(filter);

                StringBuilder builder = new();
                builder.Append("https://www.google.com/search");
                string query =
                    HttpUtility.UrlEncode($"{name} " +
                    $"site: {dt.Rows[0].Field<string>("Domen")}");
                builder.Append($"?q={query}");

                var edgeOptions = new EdgeOptions();
                using (var driver = new EdgeDriver(edgeOptions))
                {
                    driver.Url = builder.ToString();
                    var html = driver.FindElements(By.XPath("//div[@class = \"g tF2Cxc\"]//a"));
                    string list = "";
                    foreach (var element in html)
                    {
                        var temp = element.GetProperty("href");
                        var upd = Link(temp,context);
                        if (upd != null)
                        {
                            list = upd;
                            break;
                        }

                    }
                    driver.Url = list;

                    var filterO = new OptionsFilter()
                    {
                        IdContext = context,
                        Type = (int)OpType.DELAY
                    };
                    var dtO = st.OptionsT.Select(filterO);
                    if (dtO.Rows.Count != 0)
                    {
                        Thread.Sleep(int.Parse(dtO.Rows[0].Field<string>("value")));
                    }
                    var chars = ContextableSearch(driver.FindElement(By.XPath("//body")).GetAttribute("outerHTML"), context);
                    result.AddRange(chars);

                }
                for (int i = 0; i<result.Count; i++)
                {
                    var prediction = ml.Predcit(new()
                    {
                        Feature = result[i].Name +";"+result[i].Value
                    });
                    if (prediction.PredictedLabel == "Unuse")
                    {
                        result.Remove(result[i]);
                        i--;
                    }
                }
            }
            return result.ToArray();
        }

        private Models.Char[] GetCharsLink(int context, string url)
        {
            List<Models.Char> result = new List<Models.Char>();
            var filter = new ContextFilter()
            {
                Id = context
            };
            var dt = st.ContextT.Select(filter);
            var edgeOptions = new EdgeOptions();
            using (var driver = new EdgeDriver(edgeOptions))
            {
                driver.Url = url;
                var filterO = new OptionsFilter()
                {
                    IdContext = context,
                    Type = (int)OpType.DELAY
                };
                var dtO = st.OptionsT.Select(filterO);
                if (dtO.Rows.Count != 0)
                {
                    Thread.Sleep(int.Parse(dtO.Rows[0].Field<string>("value")));
                }
                var chars = ContextableSearch(driver.FindElement(By.XPath("//body")).GetAttribute("outerHTML"), context);
                result.AddRange(chars);
            }
            for(int i = 0;i<result.Count;i++)
            {
                var prediction = ml.Predcit(new()
                {
                    Feature = result[i].Name +";"+result[i].Value
                });
                if (prediction.PredictedLabel == "Unuse")
                {
                    result.Remove(result[i]);
                    i--;
                }
            }
            return result.ToArray();
        }

        private Models.Char[] Search(SOptions[] op)
        {
            List<Models.Char> result = new List<Models.Char>();
            List<Models.Char> newRes = new();
            int max = 10;
            int cur = 0;
            foreach (var context in names.ContextId)
            {
                var filter = new ContextFilter()
                {
                    Id = context
                };
                var dt = st.ContextT.Select(filter);
                var sFilter = new SearchNamesFilter()
                {
                    IdSearch = op[0].Id
                };
                var sdt = st.SearchNamesT.Select(sFilter);

                StringBuilder builder = new();
                builder.Append("https://www.google.com/search");
                string query =
                    HttpUtility.UrlEncode($"{sdt.Rows[0].Field<string>("name")} " +
                    $"site: {dt.Rows[0].Field<string>("Domen")}");
                builder.Append($"?q={query}");

                var edgeOptions = new EdgeOptions();
                using (var driver = new EdgeDriver(edgeOptions))
                {
                    driver.Url = builder.ToString();
                    var html = driver.FindElements(By.XPath("//div[@class = \"g tF2Cxc\"]//a"));
                    var filterO = new OptionsFilter()
                    {
                        IdContext = context,
                        Type = (int)OpType.LINKISSEARCH
                    };
                    var option = st.OptionsT.Select(filterO);

                    string list = "";
                    foreach (var element in html)
                    {
                        var temp = element.GetProperty("href");
                        if (temp.Contains(option.Select()[0].Field<string>("value")))
                        {
                            list = temp;
                            break;
                        }
                    }
                    driver.Url = list;
                    while (true)
                    {
                        filterO = new OptionsFilter()
                        {
                            IdContext = context,
                            Type = (int)OpType.DELAY
                        };
                        var dtO = st.OptionsT.Select(filterO);
                        if (dtO.Rows.Count != 0)
                        {
                            Thread.Sleep(int.Parse(dtO.Rows[0].Field<string>("value")));
                        }
                        var pathF = new PathsFilter()
                        {
                            IdContext = context,
                            Type = (int)PathType.CELL
                        };
                        var path = st.PathsT.Select(pathF);
                        var elemensLink = driver.FindElements(
                            By.XPath(path.Rows[0].Field<string?>("Path")));
                        pathF = new PathsFilter()
                        {
                            IdContext = context,
                            Type = (int)PathType.CELLNAME
                        };
                        path = st.PathsT.Select(pathF);
                        var elemensNames = driver.FindElements(
                            By.XPath(path.Rows[0].Field<string?>("Path")));
                        for (int i = 0; i<elemensLink.Count; i++)
                        {
                            result.Add(new()
                            {
                                Name = elemensNames[i].Text,
                                Value = elemensLink[i].GetDomProperty("href")
                            });
                            cur++;
                            if (max == cur)
                                break;
                        }
                        if (max == cur)
                            break;
                        pathF = new PathsFilter()
                        {
                            IdContext = context,
                            Type = (int)PathType.NEXT
                        };
                        path = st.PathsT.Select(pathF);
                        try
                        {
                            var next = driver.FindElement(
                                By.XPath(path.Rows[0].Field<string?>("Path")));
                            next.Click();
                        }
                        catch
                        {
                            break;
                        }
                    }
                    var pathFs = new PathsFilter()
                    {
                        IdContext = context,
                        Type = (int)PathType.TABLE
                    };
                    var paths = st.PathsT.Select(pathFs);
                    var table = paths.Rows[0].Field<string?>("Path");

                    pathFs.Type = (int)PathType.ROW;
                    paths = st.PathsT.Select(pathFs);
                    var row = paths.Rows[0].Field<string?>("Path");

                    pathFs.Type = (int)PathType.COLUMNVALUE;
                    paths = st.PathsT.Select(pathFs);
                    var columnVPath = paths.Rows[0].Field<string?>("Path");

                    pathFs.Type = (int)PathType.COLUMNTITLE;
                    paths = st.PathsT.Select(pathFs);
                    var columnTPath = paths.Rows[0].Field<string?>("Path");
                    
                    foreach (var item in result)
                    {
                        if (op[0].Option == "-100")
                        {
                            newRes.Add(item);
                        }
                        else
                        {
                            driver.Url = Link(item.Value, context);
                            var buff = Compare(driver.FindElement(By.XPath("//body"))
                                .GetAttribute("outerHTML"), op,
                                table, row, columnTPath, columnVPath, item);
                            if (buff!=null)
                                newRes.Add(buff);
                        }
                    }

                }
            }
            return newRes.ToArray();
        }

        private Models.Char Compare(string html,SOptions[] ops,
            string table,string row,string title,string value,
            Models.Char result)
        {
            int requierd = ops.Count();
            var groups = new List<Group>();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            var tableNode = doc.DocumentNode.SelectNodes(table)[0];
            var rows = tableNode.SelectNodes(row);
            int control = 0;
            foreach (var op in ops)
            {
                foreach (var item in rows)
                {
                    var local = HtmlNode.CreateNode(item.OuterHtml);
                    var res = new List<Result>();
                    foreach (var d in local.SelectNodes(title)[0].InnerText.Trim().Split(' '))
                    {
                        foreach (var n in op.Option.Split(';')[0].Split(' '))
                        {
                            res.Add(new()
                            {
                                Name = n,
                                Data = d,
                                Value = Fuzz.PartialRatio(d, n)
                            });
                        }
                    }
                    res.Add(new()
                    {
                        Name = op.Option.Split(';')[1],
                        Data = local.SelectNodes(value)[0].InnerText.Trim(),
                        Value = Fuzz.PartialRatio(op.Option,
                        local.SelectNodes(value)[0].InnerText.Trim())<70
                        ?0: Fuzz.PartialRatio(op.Option,
                        local.SelectNodes(value)[0].InnerText.Trim())*2
                    });
                    int[] values = new int[res.Count];
                    for (int i = 0; i < res.Count; i++)
                    {
                        values[i] = res[i].Value<=30?0:res[i].Value;
                    }
                    groups.Add(new()
                    {
                        Results = res,
                        Avg = (int)values.Average()
                    });
                }
                var groups2 = groups.OrderBy(x => x.Avg);
                var max = groups2.Last();
                if(max.Avg > 50)
                {
                    control++;
                }
            }
            if (requierd == control)
            {
                return result;
            }
            return null;
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
                if (!link.Contains(dt.Rows[0].Field<string>("value")))
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
                var local = HtmlNode.CreateNode(item.OuterHtml);
                chars.Add(new Models.Char() {
                    Name = local.SelectNodes(columnTPath)[0].InnerText,
                    Value = local.SelectNodes(columnVPath)[0].InnerText
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
