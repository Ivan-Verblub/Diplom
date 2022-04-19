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
    public class SStatusController : ControllerBase
    {
        private StaticTables st = StaticTables.Instance;
        [HttpGet("Select")]
        public SStatus[] Select()
        {
            var dt = st.SStatusT.Select();
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var sStatus = new SStatus[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                sStatus[i] = new()
                {
                    IdStatus = row.Field<int?>("idstatus"),
                    Status = row.Field<string>("status")
                };
                i++;
            }
            return sStatus;
        }

        [HttpPost("Select")]
        public SStatus[] Select(SStatusFilter sStatusF)
        {
            var dt = st.SStatusT.Select(sStatusF);
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var sStatus = new SStatus[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                sStatus[i] = new()
                {
                    IdStatus = row.Field<int?>("idstatus"),
                    Status = row.Field<string>("status")
                };
                i++;
            }
            return sStatus;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<SStatus>> Insert(SStatus sStatus)
        {
            string er = st.SStatusT.Insert(sStatus);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), sStatus);
            return BadRequest(er);
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<SStatus>> Delete(SStatus sStatus)
        {
            string er = st.SStatusT.Delete(sStatus);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), sStatus);
            return BadRequest(er);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<SStatus>> Update(SStatus sStatus)
        {
            string er = st.SStatusT.Update(sStatus);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), sStatus);
            return BadRequest(er);
        }
    }
}
