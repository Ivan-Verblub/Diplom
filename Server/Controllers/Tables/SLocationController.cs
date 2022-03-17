using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Server.MySQL;
using Server.MySQL.Tables;
using Server.MySQL.Tables.Filter;
using Server.MySQL.Tables.Table;
using System.Data;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers.Tables
{
    [Route("Tables/[controller]")]
    [ApiController]
    public class SLocationController : ControllerBase
    {
        private StaticTables st = StaticTables.Instance;
        [HttpGet("Select")]
        public SLocation[] Select()
        {
            var dt = st.SLocationT.Select();
            var sLocation = new SLocation[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                sLocation[i] = new()
                {
                    IdLocation = row.Field<int>("idlocation"),
                    Location = row.Field<string>("location")
                };
                i++;
            }
            return sLocation;
        }

        [HttpPost("Select")]
        public SLocation[] SelectF(SLocationFilter sLocationf)
        {
            var dt = st.SLocationT.Select(sLocationf);
            var sLocation = new SLocation[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                sLocation[i] = new()
                {
                    IdLocation = row.Field<int>("idlocation"),
                    Location = row.Field<string>("location")
                };
                i++;
            }
            return sLocation;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<SLocation>> Insert(SLocation sLocation)
        {
            string er = st.SLocationT.Insert(sLocation);
            if (er == "")
                return CreatedAtAction(nameof(Select), sLocation);
            return BadRequest(er);
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<SLocation>> Delete(SLocation sLocation)
        {
            string er = st.SLocationT.Delete(sLocation);
            if (er == "")
                return CreatedAtAction(nameof(Select), sLocation);
            return BadRequest(er);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<SLocation>> Update(SLocation sLocation)
        {
            string er = st.SLocationT.Update(sLocation);
            if (er == "")
                return CreatedAtAction(nameof(Select), sLocation);
            return BadRequest(er);
        }
    }
}
