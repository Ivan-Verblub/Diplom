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
    public class CharListObjectsController : ControllerBase
    {
        private StaticTables st = StaticTables.Instance;
        [HttpGet("Select")]
        public CharListObjects[] Select()
        {
            var dt = st.CharsOT.Select();
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var charList = new CharListObjects[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                charList[i] = new()
                {
                    Id = row.Field<int?>("idCharList"),
                    Name = row.Field<string>("Name"),
                    Value = row.Field<string>("Value"),
                    IdObject = row.Field<string>("invnumber")
                };
                i++;
            }
            return charList;
        }

        [HttpPost("Select")]
        public CharListObjects[] Select(CharListObjectsFilter listF)
        {
            var dt = st.CharsOT.Select(listF);
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var charList = new CharListObjects[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                charList[i] = new()
                {
                    Id = row.Field<int?>("idCharList"),
                    Name = row.Field<string>("Name"),
                    Value = row.Field<string>("Value"),
                    IdObject = row.Field<string>("invnumber")
                };
                i++;
            }
            return charList;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<CharListObjects>> Insert(CharListObjects charList)
        {
            string er = st.CharsOT.Insert(charList);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), charList);
            return BadRequest(er);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<CharListObjects>> Update(CharListObjects charList)
        {
            string er = st.CharsOT.Update(charList);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), charList);
            return BadRequest(er);
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<CharListObjects>> Delete(CharListObjects charList)
        {
            string er = st.CharsOT.Delete(charList);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), charList);
            return BadRequest(er);
        }
    }
}
