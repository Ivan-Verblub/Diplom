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
    public class ContextController : ControllerBase
    {
        private StaticTables st = StaticTables.Instance;
        [HttpGet("Select")]
        public Context[] Select()
        {
            var dt = st.ContextT.Select();
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var context = new Context[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                context[i] = new()
                {
                    Id = row.Field<int?>("idContext"),
                    Domen = row.Field<string>("Domen")
                };
                i++;
            }
            return context;
        }

        [HttpPost("Select")]
        public Context[] Select(ContextFilter contextF)
        {
            var dt = st.ContextT.Select(contextF);
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var context = new Context[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                context[i] = new()
                {
                    Id = row.Field<int?>("idContext"),
                    Domen = row.Field<string>("Domen")
                };
                i++;
            }
            return context;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<Context>> Insert(Context context)
        {
            string er = st.ContextT.Insert(context);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), context);
            return BadRequest(er);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Context>> Update(Context context)
        {
            string er = st.ContextT.Update(context);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), context);
            return BadRequest(er);
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<Context>> Delete(Context context)
        {
            string er = st.ContextT.Delete(context);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), context);
            return BadRequest(er);
        }
    }
}
