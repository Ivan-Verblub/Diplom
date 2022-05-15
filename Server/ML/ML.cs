using Microsoft.ML;
using Microsoft.ML.Data;
using MySql.Data.MySqlClient;
using Server.Controllers.Models;
using Server.MySQL;

namespace Server.ML
{
    public class ML
    {
        private MLContext _mlContext;
        private IDataView _test;
        private IDataView _train;
        private ITransformer _model;
        public static ML Instance
        { 
            get
            {
                if (_instance == null)
                    _instance = new ML();
                return _instance;
            }
        }
        private static ML _instance;
        private ML()
        {
            _mlContext = new MLContext(0);
        }

        public void LoadData(string dataSet, float split)
        {

            DatabaseLoader loader = _mlContext.Data.CreateDatabaseLoader<Data>();
            DatabaseSource source;
            using (Connector connector = new Connector(
                Param.Settings.host, Param.Settings.user, Param.Settings.user))
            {
                connector.Connection.ConnectionString += ";DataBase = gos;";
                source = new DatabaseSource(
                    MySqlClientFactory.Instance,
                    connector.Connection.ConnectionString,
                    $"SELECT data.Feature,data.Label " +
                    $"FROM dataset INNER JOIN data ON dataset.iddataset = data.iddataset " +
                    $"WHERE data.idDataSet = '{dataSet}';");
            }
            var dataView = loader.Load(source);
            var spliter = _mlContext.Data.TrainTestSplit(dataView,split);
            _test = spliter.TestSet;
            _train = spliter.TrainSet;
        }

        public MulticlassClassificationMetrics Train()
        {
            IEstimator<ITransformer> dataPrepEstimator =
                _mlContext.Transforms.Text.FeaturizeText("Features")
                .Append(_mlContext.Transforms.Conversion.MapValueToKey("Label"))
                .Append(_mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy())
                .Append(_mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));
            _model = dataPrepEstimator.Fit(_train);

            return _mlContext.MulticlassClassification.Evaluate(_model.Transform(_test));
                        
        }

        public PData Predcit(Data data)
        {
            using (var predictor = _mlContext.Model.CreatePredictionEngine<Data,PData>(_model))
            {
                return predictor.Predict(data);
            }
        }

        public byte[] Save(string name)
        {
            string path =
                Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.MyDocuments),
                    $"{name}.zip");
            _mlContext.Model.Save(_model, _train.Schema,path);
            byte[] buff = File.ReadAllBytes(path);
            File.Delete(path);
            return buff;
        }

        public void Load(byte[] bytes)
        {
            DataViewSchema schema;
            string path = 
                Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.MyDocuments),
                    $"{DateTime.Now.Ticks}.zip");
            File.WriteAllBytes(path,bytes);
            _model = _mlContext.Model.Load(path,out schema);
        }
    }
}
