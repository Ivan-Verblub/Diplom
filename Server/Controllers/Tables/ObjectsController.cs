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
    public class ObjectsController : ControllerBase
    {
        private StaticTables st = StaticTables.Instance;
        [HttpGet("Select")]
        public Objects[] Select()
        {
            var dt = st.ObjectsT.Select();
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var objects = new Objects[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                objects[i] = new()
                {
                    InvNumber = row.Field<string>("invnumber"),
                    Name = row.Field<string>("name"),
                    Cost = row.Field<float?>("cost"),
                    IdStatus = row.Field<int?>("idstatus"),
                    Status = row.Field<string>("status"),
                    IdLocation = row.Field<int?>("idLocation"),
                    Location = row.Field<string>("location"),
                    IdCat = row.Field<int?>("idcat"),
                    Cat = row.Field<string>("name1"),
                    IdRequest = row.Field<int?>("idrequest"),
                    RName = row.Field<string>("name2")
                };
                i++;
            }
            return objects;
        }

        [HttpPost("Select")]
        public Objects[] Select(ObjectsFilter objectsF)
        {
            var dt = st.ObjectsT.Select(objectsF);
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var objects = new Objects[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                objects[i] = new()
                {
                    InvNumber = row.Field<string>("invnumber"),
                    Name = row.Field<string>("name"),
                    Cost = row.Field<float?>("cost"),
                    IdStatus = row.Field<int?>("idstatus"),
                    Status = row.Field<string>("status"),
                    IdLocation = row.Field<int?>("idLocation"),
                    Location = row.Field<string>("location"),
                    IdCat = row.Field<int?>("idcat"),
                    Cat = row.Field<string>("name1"),
                    IdRequest = row.Field<int?>("idrequest"),
                    RName = row.Field<string>("name2")
                };
                i++;
            }
            return objects;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<Objects>> Insert(Objects objects)
        {
            string er = st.ObjectsT.Insert(objects);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), objects);
            return BadRequest(er);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Objects>> Update(Objects objects)
        {
            string er = st.ObjectsT.Update(objects);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), objects);
            return BadRequest(er);
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<Objects>> Delete(Objects objects)
        {
            string er = st.ObjectsT.Delete(objects);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), objects);
            return BadRequest(er);
        }
    }
}
