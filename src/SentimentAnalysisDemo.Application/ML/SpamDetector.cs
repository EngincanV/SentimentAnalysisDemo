using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.ML;
using SentimentAnalysisDemo.ML.Model;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace SentimentAnalysisDemo.ML;

public class SpamDetector : ISpamDetector, ITransientDependency
{
    public async Task CheckAsync(string text)
    {
        var mlContext = new MLContext();

        var modelPath = Path.Combine(Environment.CurrentDirectory, "ML", "Data", "spam_data_model.zip");
        ITransformer model;

        //👇 Load the model from the .ZIP file, if the trained data is already saved into the ZIP file. 👇
        if (File.Exists(modelPath))
        {
            model = mlContext.Model.Load(modelPath, out DataViewSchema inputSchema);
        }
        else
        {
            var dataPath = Path.Combine(Environment.CurrentDirectory, "ML", "Data", "spam_data.csv");

            //* Load Data 👇
            IDataView dataView = mlContext.Data.LoadFromTextFile<SentimentAnalyzeInput>(dataPath, hasHeader: true, separatorChar: ',');

            //* Split data to train-test data 👇
            DataOperationsCatalog.TrainTestData trainTestSplit = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
            IDataView trainingData = trainTestSplit.TrainSet; //80% of the data.
            IDataView testData = trainTestSplit.TestSet; //20% of the data.

            //* Common data process configuration with pipeline data transformations + choose and set the training algorithm 👇
            var estimator = mlContext.Transforms.Text.FeaturizeText(outputColumnName: "Features", inputColumnName: nameof(SentimentAnalyzeInput.Message))
                .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features"));

            //* Train the model 👇
            model = estimator.Fit(trainingData);
        }

        //* Predict 👇
        var sentimentAnalyzeInput = new SentimentAnalyzeInput
        {
            Message = text
        };

        var predictionEngine = mlContext.Model.CreatePredictionEngine<SentimentAnalyzeInput, SentimentAnalyzeResult>(model);
        var result = predictionEngine.Predict(sentimentAnalyzeInput);
        if (IsSpam(result))
        {
            throw new UserFriendlyException("Spam detected! Please update the message!");
        }
    }

    private static bool IsSpam(SentimentAnalyzeResult result)
    {
        //1 -> spam / 0 -> ham (for 'Prediction' column)
        return result is { Prediction: true, Probability: >= 0.5f };
    }
}