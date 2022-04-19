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
    public class LearningHistoryController : ControllerBase
    {
        private StaticTables st = StaticTables.Instance;
        [HttpGet("Select")]
        public LearningHistory[] Select()
        {
            var dt = st.LearningHistoryT.Select();
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var learningHistories = new LearningHistory[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                learningHistories[i] = new()
                {
                    Id = row.Field<int?>("idlearninghistroy"),
                    Date = row.Field<DateTime?>("date"),
                    Iter = row.Field<int?>("iteration"),
                    IdDataSet = row.Field<int?>("idDataSet"),
                    SetName = row.Field<string>("setName"),
                    Comment = row.Field<string>("comment"),
                    Version = row.Field<string>("version")
                };
                i++;
            }
            return learningHistories;
        }

        [HttpPost("Select")]
        public LearningHistory[] Select(LearningHistoryFilter learningHistoryF)
        {
            var dt = st.LearningHistoryT.Select(learningHistoryF);
            if (dt.Rows.Count==0)
            {
                return null;
            }
            var learningHistories = new LearningHistory[dt.Rows.Count];
            int i = 0;
            foreach (var row in dt.Select())
            {
                learningHistories[i] = new()
                {
                    Id = row.Field<int?>("idlearninghistroy"),
                    Date = row.Field<DateTime?>("date"),
                    Iter = row.Field<int?>("iteration"),
                    IdDataSet = row.Field<int?>("idDataSet"),
                    SetName = row.Field<string>("setName"),
                    Comment = row.Field<string>("comment"),
                    Version = row.Field<string>("version")
                };
                i++;
            }
            return learningHistories;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult<LearningHistory>> Insert(LearningHistory learningHistory)
        {
            string er = st.LearningHistoryT.Insert(learningHistory);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), learningHistory);
            return BadRequest(er);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<LearningHistory>> Update(LearningHistory learningHistory)
        {
            string er = st.LearningHistoryT.Update(learningHistory);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), learningHistory);
            return BadRequest(er);
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<LearningHistory>> Delete(LearningHistory learningHistory)
        {
            string er = st.LearningHistoryT.Delete(learningHistory);
            if (er == "")
                return CreatedAtAction(nameof(this.Select), learningHistory);
            return BadRequest(er);
        }
    }
}
