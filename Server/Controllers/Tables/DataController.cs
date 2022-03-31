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
    public class DataController : ControllerBase
    {
        private StaticTables st = StaticTables.Instance;
        [HttpGet("Select")]
        public DatasTable[] Select()
        {
            var dt = st.DataT.Select();
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var data = new DatasTable[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                data[i] = new()
                {
                    IdData = row.Field<int>("idData"),
                    Feature = row.Field<string>("Feature"),
                    Label = row.Field<string>("Label"),
                    IdDataSet = row.Field<int>("idDataSet"),
                    SetName = row.Field<string>("setName")
                };
                i++;
            }
            return data;
        }

        [HttpPost("Select")]
        public DatasTable[] Select(DatasFilter dataF)
        {
            var dt = st.DataT.Select(dataF);
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var data = new DatasTable[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                data[i] = new()
                {
                    IdData = row.Field<int>("idData"),
                    Feature = row.Field<string>("Feature"),
                    Label = row.Field<string>("Label"),
                    IdDataSet = row.Field<int>("idDataSet"),
                    SetName = row.Field<string>("setName")
                };
                i++;
            }
            return data;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<DatasTable>> Insert(DatasTable data)
        {
            string er = st.DataT.Insert(data);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), data);
            return BadRequest(er);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<DatasTable>> Update(DatasTable data)
        {
            string er = st.DataT.Update(data);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), data);
            return BadRequest(er);
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<DatasTable>> Delete(DatasTable data)
        {
            string er = st.DataT.Delete(data);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), data);
            return BadRequest(er);
        }
    }
}
