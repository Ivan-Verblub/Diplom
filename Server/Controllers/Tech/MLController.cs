using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.ML;
using System.IO;
using Microsoft.ML.Data;
namespace Server.Controllers.Tech
{
    [Route("Tech/[controller]")]
    [ApiController]
    public class MLController : ControllerBase
    {
        private ML.ML ml = ML.ML.Instance;

        [HttpPost("LoadData/{dataSet}/{split}")]
        public async void LoadData(string dataSet, float split)
        {
            await Task.Run(() =>
            {
                ml.LoadData(dataSet, split);
            });
        }

        [HttpGet("Train")]
        public async Task<MulticlassClassificationMetrics> Train()
        {
            return await Task.Run(() =>
            {
                return ml.Train();
            });
        }

        [HttpPost("Predict")]
        public async Task<PData> Predict(Data data)
        {
            return await Task.Run(() =>
            {
                return ml.Predcit(data);
            });
        }

        [HttpPost("Save/{path}")]
        public string Save(string path)
        {
            return Convert.ToBase64String(ml.Save(path.Split('\\').Last()));
        }

        [HttpPost("Load/{bytes}")]
        public Task Load(string bytes)
        {
            return Task.Run(() => 
            {
                ml.Load(Convert.FromBase64String(bytes));
            });
        }
    }
}
