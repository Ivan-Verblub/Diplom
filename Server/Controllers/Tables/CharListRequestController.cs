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
    public class CharListRequestController : ControllerBase
    {
        private StaticTables st = StaticTables.Instance;
        [HttpGet("Select")]
        public CharListRequest[] Select()
        {
            var dt = st.CharsRT.Select();
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var charList = new CharListRequest[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                charList[i] = new()
                {
                    Id = row.Field<int>("idCharList"),
                    Name = row.Field<string>("Name"),
                    Value = row.Field<string>("Value"),
                    IdRequest = row.Field<int>("idrequestinner")
                };
                i++;
            }
            return charList;
        }

        [HttpPost("Select")]
        public CharListRequest[] Select(CharListRequestFilter listF)
        {
            var dt = st.CharsRT.Select(listF);
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var charList = new CharListRequest[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                charList[i] = new()
                {
                    Id = row.Field<int>("idCharList"),
                    Name = row.Field<string>("Name"),
                    Value = row.Field<string>("Value"),
                    IdRequest = row.Field<int>("idrequestinner")
                };
                i++;
            }
            return charList;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<CharListRequest>> Insert(CharListRequest charList)
        {
            string er = st.CharsRT.Insert(charList);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), charList);
            return BadRequest(er);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<CharListRequest>> Update(CharListRequest charList)
        {
            string er = st.CharsRT.Update(charList);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), charList);
            return BadRequest(er);
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<CharListRequest>> Delete(CharListRequest charList)
        {
            string er = st.CharsRT.Delete(charList);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), charList);
            return BadRequest(er);
        }
    }
}
