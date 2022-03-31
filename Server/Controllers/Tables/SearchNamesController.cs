using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.MySQL;
using Server.MySQL.Tables.Filter;
using Server.MySQL.Tables.Table;
using System.Data;

namespace Server.Controllers.Tables
{
    [Route("Tables/[controller]")]
    [ApiController]
    public class SearchNamesController : ControllerBase
    {
        private StaticTables st = StaticTables.Instance;
        [HttpGet("Select")]
        public SearchNames[] Select()
        {
            var dt = st.SearchNamesT.Select();
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var objects = new SearchNames[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                objects[i] = new()
                {
                    Id = row.Field<int>("idSearchNames"),
                    Name = row.Field<string>("name"),
                    IdSearch = row.Field<int>("idSearchContext"),
                    SearchName = row.Field<string>("name1")
                };
                i++;
            }
            return objects;
        }

        [HttpPost("Select")]
        public SearchNames[] Select(SearchNamesFilter objectsF)
        {
            var dt = st.SearchNamesT.Select(objectsF);
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var objects = new SearchNames[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                objects[i] = new()
                {
                    Id = row.Field<int>("idSearchNames"),
                    Name = row.Field<string>("name"),
                    IdSearch = row.Field<int>("idSearchContext"),
                    SearchName = row.Field<string>("name1")
                };
                i++;
            }
            return objects;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<SearchNames>> Insert(SearchNames objects)
        {
            string er = st.SearchNamesT.Insert(objects);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), objects);
            return BadRequest(er);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<SearchNames>> Update(SearchNames objects)
        {
            string er = st.SearchNamesT.Update(objects);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), objects);
            return BadRequest(er);
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<SearchNames>> Delete(SearchNames objects)
        {
            string er = st.SearchNamesT.Delete(objects);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), objects);
            return BadRequest(er);
        }
    }
}
