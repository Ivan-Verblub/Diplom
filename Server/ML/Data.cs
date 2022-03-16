using Microsoft.ML.Data;
namespace Server.ML
{
    public class Data
    {
        [LoadColumn(0)]
        [ColumnName("Features")]
        public string Feature { get; set; }
        [LoadColumn(1)]
        public string Label { get; set; }
    }

    public class PData
    { 
        public string PredictedLabel { get; set; } 
    }
}
