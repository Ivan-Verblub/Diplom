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
    public class ContextableController : ControllerBase
    {
        private StaticTables st = StaticTables.Instance;
        [HttpGet("Select")]
        public Contextable[] Select()
        {
            var dt = st.ContextableT.Select();
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var context = new Contextable[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                context[i] = new()
                {
                    Id = row.Field<int?>("idlearninghistroy"),
                    Date = row.Field<DateTime?>("date"),
                    Iter = row.Field<int?>("iteration"),
                    IdDataSet = row.Field<int?>("iddataset"),
                    SetName = row.Field<string>("setName"),
                    Comment = row.Field<string>("comment"),
                    Version = row.Field<string>("version"),
                    IdSearch = row.Field<int?>("idSearchContext"),
                    SearchName = row.Field<string>("name")
                };
                i++;
            }
            return context;
        }

        [HttpPost("Select")]
        public Contextable[] Select(ContextableFilter contextF)
        {
            var dt = st.ContextableT.Select(contextF);
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var context = new Contextable[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                context[i] = new()
                {
                    Id = row.Field<int?>("idlearninghistroy"),
                    Date = row.Field<DateTime?>("date"),
                    Iter = row.Field<int?>("iteration"),
                    IdDataSet = row.Field<int?>("iddataset"),
                    SetName = row.Field<string>("setName"),
                    Comment = row.Field<string>("comment"),
                    Version = row.Field<string>("version"),
                    IdSearch = row.Field<int?>("idSearchContext"),
                    SearchName = row.Field<string>("name")
                };
                i++;
            }
            return context;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<Contextable>> Insert(Contextable context)
        {
            string er = st.ContextableT.Insert(context);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), context);
            return BadRequest(er);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Contextable>> Update(Contextable context)
        {
            string er = st.ContextableT.Update(context);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), context);
            return BadRequest(er);
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<Contextable>> Delete(Contextable context)
        {
            string er = st.ContextableT.Delete(context);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), context);
            return BadRequest(er);
        }
    }
}
