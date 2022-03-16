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
        [HttpGet("Select")]
        public Objects[] Select()
        {
            var dt = StaticTables.ObjectsT.Select();
            var objects = new Objects[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                objects[i] = new()
                {
                    InvNumber = row.Field<string>("invnumber"),
                    Name = row.Field<string>("name"),
                    Chars = row.Field<string>("char"),
                    Cost = row.Field<float>("cost"),
                    IdStatus = row.Field<int>("idstatus"),
                    Status = row.Field<string>("status"),
                    IdLocation = row.Field<int>("idLocation"),
                    Location = row.Field<string>("location"),
                    IdCat = row.Field<int>("idcat"),
                    Cat = row.Field<string>("name1"),
                    IdRequest = row.Field<int>("idrequest"),
                    RName = row.Field<string>("name2")
                };
                i++;
            }
            return objects;
        }

        [HttpPost("Select")]
        public Objects[] Select(ObjectsFilter objectsF)
        {
            var dt = StaticTables.ObjectsT.Select(objectsF);
            var objects = new Objects[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                objects[i] = new()
                {
                    InvNumber = row.Field<string>("invnumber"),
                    Name = row.Field<string>("name"),
                    Chars = row.Field<string>("char"),
                    Cost = row.Field<float>("cost"),
                    IdStatus = row.Field<int>("idstatus"),
                    Status = row.Field<string>("status"),
                    IdLocation = row.Field<int>("idLocation"),
                    Location = row.Field<string>("location"),
                    IdCat = row.Field<int>("idcat"),
                    Cat = row.Field<string>("name1"),
                    IdRequest = row.Field<int>("idrequest"),
                    RName = row.Field<string>("name2")
                };
                i++;
            }
            return objects;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<Objects>> Insert(Objects objects)
        {
            string er = StaticTables.ObjectsT.Insert(objects);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), objects);
            return BadRequest(er);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Objects>> Update(Objects objects)
        {
            string er = StaticTables.ObjectsT.Update(objects);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), objects);
            return BadRequest(er);
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<Objects>> Delete(Objects objects)
        {
            string er = StaticTables.ObjectsT.Delete(objects);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), objects);
            return BadRequest(er);
        }
    }
}
