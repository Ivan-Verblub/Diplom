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
    public class SCatController : ControllerBase
    {
        [HttpGet("Select")]
        public Scat[] SelectSC()
        {
            var dt = StaticTables.ScatT.Select();
            var scat = new Scat[dt.Rows.Count];
            int i = 0;
            foreach(var row in dt.Select())
            {
                scat[i] = new()
                {
                    IdCat = row.Field<int>("idcat"),
                    Name = row.Field<string>("name")
                };
                i++;
            }
            return scat;
        }
        [HttpPost("Select")]
        public Scat[] SelectSC(ScatFilter scatf)
        {
            var dt = StaticTables.ScatT.Select(scatf);
            var scat = new Scat[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                scat[i] = new()
                {
                    IdCat = row.Field<int>("idcat"),
                    Name = row.Field<string>("name")
                };
                i++;
            }
            return scat;
        }
        [HttpPost("Insert")]
        public async Task<ActionResult<Scat>> InsertSC(Scat scat)
        {
            string er = StaticTables.ScatT.Insert(scat);
            if(er == "")
                return CreatedAtAction(nameof(this.SelectSC), scat);
            return BadRequest(er);

        }

        [HttpPost("Delete")]
        public async Task<ActionResult<Scat>> Delete(Scat scat)
        {
            string er = StaticTables.ScatT.Delete(scat);
            if (er == "")
                return CreatedAtAction(nameof(this.SelectSC), scat);
            return BadRequest(er);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Scat>> UpdateSC(Scat scat)
        {
            string er = StaticTables.ScatT.Update(scat);
            if (er == "")
                return CreatedAtAction(nameof(this.SelectSC), scat);
            return BadRequest(er);
        }

    }
}
