using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Server.MySQL;
using Server.MySQL.Tables;
using Server.MySQL.Tables.Filter;
using Server.MySQL.Tables.Table;
using System.Data;
using DataSet = Server.MySQL.Tables.Table.DataSet;

namespace Server.Controllers.Tables
{
    [Route("Tables/[controller]")]
    [ApiController]
    public class DataSetController : ControllerBase
    {
        [HttpGet("Select")]
        public DataSet[] Select()
        {
            var dt = StaticTables.DataSetT.Select();
            var dataSet = new DataSet[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                dataSet[i] = new()
                {
                    IdDataSet = row.Field<int>("iddataset"),
                    SetName = row.Field<string>("setName")
                };
                i++;
            }
            return dataSet;
        }
        [HttpPost("Select")]
        public DataSet[] SelectF(DataSetFilter dataSetF)
        {
            var dt = StaticTables.DataSetT.Select(dataSetF);
            var dataSet = new DataSet[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                dataSet[i] = new()
                {
                    IdDataSet = row.Field<int>("iddataset"),
                    SetName = row.Field<string>("setName")
                };
                i++;
            }
            return dataSet;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<DataSet>> Insert(DataSet dataSet)
        {
            string er = StaticTables.DataSetT.Insert(dataSet);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), dataSet);
            return BadRequest(er);
        }
        [HttpPost("Update")]
        public async Task<ActionResult<DataSet>> Update(DataSet dataSet)
        {
            string er = StaticTables.DataSetT.Update(dataSet);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), dataSet);
            return BadRequest(er);
        }
        [HttpPost("Delete")]
        public async Task<ActionResult<DataSet>> Delete(DataSet dataSet)
        {
            string er = StaticTables.DataSetT.Delete(dataSet);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), dataSet);
            return BadRequest(er);
        }
    }
}
