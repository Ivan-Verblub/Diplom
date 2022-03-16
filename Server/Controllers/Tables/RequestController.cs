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
        [HttpGet("Select")]
        public Request[] Select()
        {
            var dt = StaticTables.RequestT.Select();
            var request = new Request[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                request[i] = new()
                {
                    Id = row.Field<int>("idrequest"),
                    Name = row.Field<string>("name"),
                    File = Convert.ToBase64String(row.Field<byte[]>("File")),
                    IdLearning = row.Field<int>("idlearninghistroy"),
                    Comment = row.Field<string>("comment"),
                    IdUser = row.Field<int>("iduser"),
                    Login = row.Field<string>("string")
                };
                i++;
            }
            return request;
        }

        [HttpPost("Select")]
        public Request[] Select(RequestFilter requestF)
        {
            var dt = StaticTables.RequestT.Select(requestF);
            var request = new Request[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                request[i] = new()
                {
                    Id = row.Field<int>("idrequest"),
                    Name = row.Field<string>("name"),
                    File = Convert.ToBase64String(row.Field<byte[]>("File")),
                    IdLearning = row.Field<int>("idlearninghistroy"),
                    Comment = row.Field<string>("comment"),
                    IdUser = row.Field<int>("iduser"),
                    Login = row.Field<string>("string")
                };
                i++;
            }
            return request;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<Request>> Insert(Request request)
        {
            string er = StaticTables.RequestT.Insert(request);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), request);
            return BadRequest(er);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Request>> Update(Request request)
        {
            string er = StaticTables.RequestT.Update(request);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), request);
            return BadRequest(er);
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<Request>> Delete(Request request)
        {
            string er = StaticTables.RequestT.Delete(request);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), request);
            return BadRequest(er);
        }
    }
}
