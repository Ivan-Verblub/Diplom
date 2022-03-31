using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gos.Server.Models.Requesting
{

    public class Metrics
    {
        public double logLoss { get; set; }
        public double logLossReduction { get; set; }
        public double macroAccuracy { get; set; }
        public double microAccuracy { get; set; }
        public double topKAccuracy { get; set; }
        public double topKPredictionCount { get; set; }
        public double[] topKAccuracyForAllK { get; set; }
        public double[] perClassLogLoss { get; set; }
        public Confusionmatrix confusionMatrix { get; set; }

        public override string ToString()
        {
            string result = $"logLoss:{logLoss}\n";
            result += $"logLossReduction:{logLossReduction}\n";
            result += $"macroAccuracy:{macroAccuracy}\n";
            result += $"microAccuracy:{microAccuracy}\n";
            result += $"topKAccuracy:{topKAccuracy}\n";
            result += $"topKPredictionCount:{topKPredictionCount}\n";
            result += "topKAccuracyForAllK:";
            try
            {
                foreach (var item in topKAccuracyForAllK)
                    result += $"{item} ";
            }
            catch { }
            result += "\nperClassLogLoss:";
            try { 
            foreach (var item in perClassLogLoss)
                result += $"{item} ";
            }
            catch { }
            result += "\n"+confusionMatrix.ToString();
            return result;
        }
    }

    public class Confusionmatrix
    {
        public double[] perClassPrecision { get; set; }
        public double[] perClassRecall { get; set; }
        public int[][] counts { get; set; }
        public int numberOfClasses { get; set; }
        public override string ToString()
        {
            string result = "perClassPrecision:";
            foreach (var item in perClassPrecision)
                result += $"{item} ";
            result += "\nperClassRecall:";
            foreach (var item in perClassRecall)
                result += $"{item} ";
            result += "\ncounts:";
            foreach (var item in counts)
            {
                foreach (var i in item)
                    result += $"{i} ";
                result += "\n";
            }
            result += $"numberOfClasses:{numberOfClasses}";
            return result;
        }
    }

}
