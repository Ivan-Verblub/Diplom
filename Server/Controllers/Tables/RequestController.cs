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
    [Route("Tables/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private StaticTables st = StaticTables.Instance;
        [HttpGet("Select")]
        public Request[] Select()
        {
            var dt = st.RequestT.Select();
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var request = new Request[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                request[i] = new()
                {
                    Id = row.Field<int?>("idrequest"),
                    Name = row.Field<string>("name"),
                    File = Convert.ToBase64String(row.Field<byte[]?>("File")),
                    IdLearning = row.Field<int?>("idlearninghistroy"),
                    Comment = row.Field<string>("comment")
                };
                i++;
            }
            return request;
        }

        [HttpPost("Select")]
        public Request[] Select(RequestFilter requestF)
        {
            var dt = st.RequestT.Select(requestF);
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var request = new Request[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                request[i] = new()
                {
                    Id = row.Field<int?>("idrequest"),
                    Name = row.Field<string>("name"),
                    File = Convert.ToBase64String(row.Field<byte[]?>("File")),
                    IdLearning = row.Field<int?>("idlearninghistroy"),
                    Comment = row.Field<string>("comment")
                };
                i++;
            }
            return request;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<Request>> Insert(Request request)
        {
            string er = st.RequestT.Insert(request);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), request);
            return BadRequest(er);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Request>> Update(Request request)
        {
            string er = st.RequestT.Update(request);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), request);
            return BadRequest(er);
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<Request>> Delete(Request request)
        {
            string er = st.RequestT.Delete(request);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), request);
            return BadRequest(er);
        }
    }
}
