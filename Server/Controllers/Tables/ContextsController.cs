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
    public class ContextsController : ControllerBase
    {
        private StaticTables st = StaticTables.Instance;
        [HttpGet("Select")]
        public Contexts[] Select()
        {
            var dt = st.ContextsT.Select();
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var context = new Contexts[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                context[i] = new()
                {
                    Id = row.Field<int?>("idContexts"),
                    IdContext = row.Field<int?>("idContext"),
                    Domen = row.Field<string>("domen"),
                    IdContextable = row.Field<int?>("idlearninghistroy"),
                    Comment = row.Field<string>("comment")
                };
                i++;
            }
            return context;
        }

        [HttpPost("Select")]
        public Contexts[] Select(ContextsFilter contextF)
        {
            var dt = st.ContextsT.Select(contextF);
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var context = new Contexts[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                context[i] = new()
                {
                    Id = row.Field<int?>("idContexts"),
                    IdContext = row.Field<int?>("idContext"),
                    Domen = row.Field<string>("domen"),
                    IdContextable = row.Field<int?>("idlearninghistroy"),
                    Comment = row.Field<string>("comment")
                };
                i++;
            }
            return context;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<Contexts>> Insert(Contexts context)
        {
            string er = st.ContextsT.Insert(context);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), context);
            return BadRequest(er);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Contexts>> Update(Contexts context)
        {
            string er = st.ContextsT.Update(context);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), context);
            return BadRequest(er);
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<Contexts>> Delete(Contexts context)
        {
            string er = st.ContextsT.Delete(context);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), context);
            return BadRequest(er);
        }
    }
}
