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
    public class ObjectsHistoryController : ControllerBase
    {
        [HttpGet("Select")]
        public ObjectsHistory[] Select()
        {
            var dt = StaticTables.ObjectsHistoryT.Select();
            var objectsHistory = new ObjectsHistory[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                objectsHistory[i] = new()
                {
                    Id = row.Field<int>("idobjectshistory"),
                    InvNumber = row.Field<string>("invnumber"),
                    Name = row.Field<string>("name"),
                    IdStatus = row.Field<int>("idstatus"),
                    Status = row.Field<string>("status"),
                    IdLocation = row.Field<int>("idLocation"),
                    Location = row.Field<string>("location"),
                    Date = row.Field<DateTime>("date"),
                    comment = row.Field<string>("comment")
                };
                i++;
            }
            return objectsHistory;
        }

        [HttpPost("Select")]
        public ObjectsHistory[] Select(ObjectsHistoryFilter objectsF)
        {
            var dt = StaticTables.ObjectsHistoryT.Select(objectsF);
            var objectsHistory = new ObjectsHistory[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                objectsHistory[i] = new()
                {
                    Id = row.Field<int>("idobjectshistory"),
                    InvNumber = row.Field<string>("invnumber"),
                    Name = row.Field<string>("name"),
                    IdStatus = row.Field<int>("idstatus"),
                    Status = row.Field<string>("status"),
                    IdLocation = row.Field<int>("idLocation"),
                    Location = row.Field<string>("location"),
                    Date = row.Field<DateTime>("date"),
                    comment = row.Field<string>("comment")
                };
                i++;
            }
            return objectsHistory;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<ObjectsHistory>> Insert(ObjectsHistory objects)
        {
            string er = StaticTables.ObjectsHistoryT.Insert(objects);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), objects);
            return BadRequest(er);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<ObjectsHistory>> Update(ObjectsHistory objects)
        {
            string er = StaticTables.ObjectsHistoryT.Update(objects);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), objects);
            return BadRequest(er);
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<ObjectsHistory>> Delete(ObjectsHistory objects)
        {
            string er = StaticTables.ObjectsHistoryT.Delete(objects);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), objects);
            return BadRequest(er);
        }
    }
}
