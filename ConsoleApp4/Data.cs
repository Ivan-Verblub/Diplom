using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace ConsoleApp4
{
    public class DataRw
    {
        [LoadColumn(0)]
        [ColumnName("Features")]
        public string Data { get; set; }
        [LoadColumn(1)]
        public string Label { get; set; }
    }

    public class DataPrediction
    {
        public string PredictedData { get; set; }
    }

}
