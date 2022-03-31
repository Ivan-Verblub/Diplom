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
    public class PathsController : ControllerBase
    {
        private StaticTables st = StaticTables.Instance;
        [HttpGet("Select")]
        public Paths[] Select()
        {
            var dt = st.PathsT.Select();
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var objects = new Paths[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                objects[i] = new()
                {
                    Id = row.Field<int>("idPaths"),
                    Path = row.Field<string>("path"),
                    Type = row.Field<int>("type"),
                    Cclass = row.Field<int>("class"),
                    IdContext = row.Field<int>("idContext"),
                    Domen = row.Field<string>("domen")
                };
                i++;
            }
            return objects;
        }

        [HttpPost("Select")]
        public Paths[] Select(PathsFilter objectsF)
        {
            var dt = st.PathsT.Select(objectsF);
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var objects = new Paths[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                objects[i] = new()
                {
                    Id = row.Field<int>("idPaths"),
                    Path = row.Field<string>("path"),
                    Type = row.Field<int>("type"),
                    Cclass = row.Field<int>("class"),
                    IdContext = row.Field<int>("idContext"),
                    Domen = row.Field<string>("domen")
                };
                i++;
            }
            return objects;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<Paths>> Insert(Paths objects)
        {
            string er = st.PathsT.Insert(objects);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), objects);
            return StatusCode(400,er);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Paths>> Update(Paths objects)
        {
            string er = st.PathsT.Update(objects);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), objects);
            return BadRequest(er);
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<Paths>> Delete(Paths objects)
        {
            string er = st.PathsT.Delete(objects);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), objects);
            return BadRequest(er);
        }
    }
}
