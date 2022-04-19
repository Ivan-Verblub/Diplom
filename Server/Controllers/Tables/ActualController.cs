using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Server.MySQL;
using Server.MySQL.Tables;
using Server.MySQL.Tables.Filter;
using Server.MySQL.Tables.Table;
using System.Data;

namespace Server.Controllers.Tables
{
    [ApiController]
    [Route("Tables/[controller]")]
    public class ActualController : Controller
    {
        private StaticTables st = StaticTables.Instance;

        [HttpGet("Select")]
        public Actual[] Select()
        {
            var dt = st.ActualT.Select();
            if(dt.Rows.Count==0)
            {
                return null;
            }
            var actual = new Actual[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                actual[i] = new()
                {
                    IdActual = row.Field<int?>("idactual"),
                    Name = row.Field<string>("name"),
                    Conf = Convert.ToBase64String(row.Field<byte[]>("conf")),
                    IdLearningHistory = row.Field<int?>("idlearninghistroy"),
                    Comment = row.Field<string>("comment"),
                    Version = row.Field<string>("version"),
                    Types = row.Field<int?>("type")
                };
                i++;
            }
            return actual;
        }

        [HttpPost("Select")]
        public Actual[] Select(ActualFilter actualF)
        {
            var dt = st.ActualT.Select(actualF);
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var actual = new Actual[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                actual[i] = new()
                {
                    IdActual = row.Field<int?>("idactual"),
                    Name = row.Field<string>("name"),
                    Conf = Convert.ToBase64String(row.Field<byte[]>("conf")),
                    IdLearningHistory = row.Field<int?>("idlearninghistroy"),
                    Comment = row.Field<string>("comment"),
                    Version = row.Field<string>("version"),
                    Types = row.Field<int?>("type")
                };
                i++;
            }
            return actual;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<Actual>> Insert(Actual actual)
        {
            string er = st.ActualT.Insert(actual);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), actual);
            return BadRequest(er);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Actual>> Update(Actual actual)
        {
            string er = st.ActualT.Update(actual);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), actual);
            return BadRequest(er);
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<Actual>> Delete(Actual actual)
        {
            string er = st.ActualT.Delete(actual);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), actual);
            return BadRequest(er);
        }
    }
}
