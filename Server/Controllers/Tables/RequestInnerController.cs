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
    public class RequestInnerController : ControllerBase
    {
        private StaticTables st = StaticTables.Instance;
        [HttpGet("Select")]
        public RequestInner[] Select()
        {
            var dt = st.RequestInnerT.Select();
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var requestInner = new RequestInner[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                requestInner[i] = new()
                {
                    Id = row.Field<int?>("idrequestinner"),
                    Name = row.Field<string>("name"),
                    Cost = row.Field<float?>("cost"),
                    IdCat = row.Field<int?>("idcat"),
                    Cat = row.Field<string>("name1"),
                    IdRequest = row.Field<int?>("idrequest"),
                    RName = row.Field<string>("name2"),
                    Count = row.Field<int?>("count")
                };
                i++;
            }
            return requestInner;
        }

        [HttpPost("Select")]
        public RequestInner[] Select(RequestInnerFilter requestInnerF)
        {
            var dt = st.RequestInnerT.Select(requestInnerF);
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var requestInner = new RequestInner[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                requestInner[i] = new()
                {
                    Id = row.Field<int?>("idrequestinner"),
                    Name = row.Field<string>("name"),
                    Cost = row.Field<float?>("cost"),
                    IdCat = row.Field<int?>("idcat"),
                    Cat = row.Field<string>("name"),
                    IdRequest = row.Field<int?>("idrequest"),
                    RName = row.Field<string>("name"),
                    Count = row.Field<int?>("count")
                };
                i++;
            }
            return requestInner; ;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<RequestInner>> Insert(RequestInner request)
        {
            string er = st.RequestInnerT.Insert(request);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), request);
            return BadRequest(er);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<RequestInner>> Update(RequestInner request)
        {
            string er = st.RequestInnerT.Update(request);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), request);
            return BadRequest(er);
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<RequestInner>> Delete(RequestInner request)
        {
            string er = st.RequestInnerT.Delete(request);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), request);
            return BadRequest(er);
        }
    }
}
