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
    public class OptionsController : ControllerBase
    {
        private StaticTables st = StaticTables.Instance;
        [HttpGet("Select")]
        public Options[] Select()
        {
            var dt = st.OptionsT.Select();
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var objects = new Options[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                objects[i] = new()
                {
                    Id = row.Field<int?>("idOptions"),
                    Type = row.Field<int?>("type"),
                    Value = row.Field<string>("value"),
                    IdContext = row.Field<int?>("idContext"),
                    Domen = row.Field<string>("domen")
                };
                i++;
            }
            return objects;
        }

        [HttpPost("Select")]
        public Options[] Select(OptionsFilter objectsF)
        {
            var dt = st.OptionsT.Select(objectsF);
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var objects = new Options[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                objects[i] = new()
                {
                    Id = row.Field<int?>("idOptions"),
                    Type = row.Field<int?>("type"),
                    Value = row.Field<string>("value"),
                    IdContext = row.Field<int?>("idContext"),
                    Domen = row.Field<string>("domen")
                };
                i++;
            }
            return objects;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<Options>> Insert(Options objects)
        {
            string er = st.OptionsT.Insert(objects);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), objects);
            return BadRequest(er);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Options>> Update(Options objects)
        {
            string er = st.OptionsT.Update(objects);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), objects);
            return BadRequest(er);
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<Options>> Delete(Options objects)
        {
            string er = st.OptionsT.Delete(objects);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), objects);
            return BadRequest(er);
        }
    }
}
