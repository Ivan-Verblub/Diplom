using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.MySQL;
using Server.MySQL.Tables.Filter;
using Server.MySQL.Tables.Table;
using System.Data;

namespace Server.Controllers.Tables
{
    [Route("Table/[controller]")]
    [ApiController]
    public class SearchContextController : ControllerBase
    {
        private StaticTables st = StaticTables.Instance;
        [HttpGet("Select")]
        public SearchContext[] Select()
        {
            var dt = st.SearchContextT.Select();
            var objects = new SearchContext[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                objects[i] = new()
                {
                    Id = row.Field<int>("idSearchContext"),
                    Name = row.Field<string>("Name")
                };
                i++;
            }
            return objects;
        }

        [HttpPost("Select")]
        public SearchContext[] Select(SearchContextFilter objectsF)
        {
            var dt = st.SearchContextT.Select(objectsF);
            var objects = new SearchContext[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                objects[i] = new()
                {
                    Id = row.Field<int>("idSearchContext"),
                    Name = row.Field<string>("Name")
                };
                i++;
            }
            return objects;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<SearchContext>> Insert(SearchContext objects)
        {
            string er = st.SearchContextT.Insert(objects);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), objects);
            return BadRequest(er);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<SearchContext>> Update(SearchContext objects)
        {
            string er = st.SearchContextT.Update(objects);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), objects);
            return BadRequest(er);
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<SearchContext>> Delete(SearchContext objects)
        {
            string er = st.SearchContextT.Delete(objects);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), objects);
            return BadRequest(er);
        }
    }
}
