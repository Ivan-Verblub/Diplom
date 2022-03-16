using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;
using MySql.Data.MySqlClient;

namespace ConsoleApp4
{
    class ML
    {
        public ML()
        {
            MLContext context = new MLContext(0);
            string connectionString =
                "Data Source = localhost; DataBase = testing;" +
                " user = root; password = qwerty; charset = utf8";
            string commandString = "SELECT Data,Label FROM data LIMIT 0,100";

            DatabaseLoader loader = context.Data.CreateDatabaseLoader<DataRw>();
            DatabaseSource source =
                new DatabaseSource(MySqlClientFactory.Instance, connectionString, commandString);

            IDataView data = loader.Load(source);
            //var drw = context.Data.CreateEnumerable<DataRw>(data,false);
            //var ar = drw.ToArray();
            var pipeline =
                context.Transforms.Text.FeaturizeText(outputColumnName: "Features", inputColumnName: "Features")
                .Append(context.Transforms.Conversion.MapValueToKey("Label", "Label"), TransformerScope.TrainTest)
                .Append(context.MulticlassClassification.Trainers.SdcaMaximumEntropy(maximumNumberOfIterations: 2000000))
                .Append(context.Transforms.Conversion.MapKeyToValue("PredictedData", "PredictedLabel"));

            var model = pipeline.Fit(data);
            var a = model.Transform(data);
            var predictor = context.Model.CreatePredictionEngine<DataRw, DataPrediction>(model);

            var rw = new DataRw()
            { Data = "Аксессуары" };

            var prediction = predictor.Predict(rw);

            //var TrainTestData = context.Data.TrainTestSplit(data,0.2,seed: 0);
            //var train = TrainTestData.TrainSet;
            //var test = TrainTestData.TestSet;

            //var predictions = model.Transform(test);
            //var metrics = context.MulticlassClassification.Evaluate(predictions);

            //var scores = context.MulticlassClassification.CrossValidate(data,pipeline);
            //var mean = scores.Average(x => x.Metrics.MicroAccuracy);



            //IEstimator<ITransformer> dataPrepEstimator =
            //    context.Transforms.Text.FeaturizeText("Features")
            //    .Append(context.Transforms.Conversion.MapValueToKey("Label"))
            //    .Append(context.MulticlassClassification.Trainers.
            //    SdcaMaximumEntropy(labelColumnName: "Label", featureColumnName: "Features"));
            //    //.Append(context.Transforms.Conversion.MapValueToKey("Score"));
            //ITransformer dataPrepTransformer = dataPrepEstimator.Fit(data);
            //IDataView tData = dataPrepTransformer.Transform(data);

            //var dataSplit = context.Data.TrainTestSplit(tData, 0.2);
            //IDataView train = dataSplit.TrainSet;
            //IDataView test = dataSplit.TestSet;

            //var sdcaEstimator = context.MulticlassClassification.Trainers.SdcaNonCalibrated();

            //var trainedModel = sdcaEstimator.Fit(train);
            //var trainedModelParameters = trainedModel.Model;

            //MulticlassClassificationMetrics metrics = context.MulticlassClassification.Evaluate(test);
            //double rSquared = metrics.MacroAccuracy;
            //var rw = new DataRw[]
            //{
            //    new DataRw()
            //    {
            //        Data = "Размер экрана"
            //    },
            //    new DataRw()
            //    {
            //        Data = (new char[300000]).ToString()
            //    },
            //    new DataRw()
            //    {
            //        Data = "qweqwewqerwerqwe"
            //    },
            //    new DataRw()
            //    {
            //        Data = "xdfgsxgertxfds"
            //    }
            //};
            //var d = context.Data.LoadFromEnumerable<DataRw>(rw);
            //IEstimator<ITransformer> dP =
            //    context.Transforms.Text.FeaturizeText("Features");
            //    //.Append(context.Transforms.Conversion.MapValueToKey("Label"));
            //ITransformer dPT = dP.Fit(data);
            //IDataView dPP = dPT.Transform(data);
            //var dPPP = trainedModel.Transform(dPP);


            ////var predict = context.Model.CreatePredictionEngine<DataRw, DataPrediction>(trainedModel).Predict();
            //var a = dPPP.GetColumn<string>("Score").ToArray();
        }


    }
}
