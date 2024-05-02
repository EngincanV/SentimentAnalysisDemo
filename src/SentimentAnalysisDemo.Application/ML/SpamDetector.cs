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
    private static readonly string DataPath = Path.Combine(Environment.CurrentDirectory, "ML", "Data", "spam_data.csv");
    private static readonly string ModelPath = Path.Combine(Environment.CurrentDirectory, "ML", "Data", "spam_data_model.zip");
    
    public async Task CheckAsync(string text)
    {
        var mlContext = new MLContext();
        
        //Step 1: Load Data
        IDataView dataView = mlContext.Data.LoadFromTextFile<SentimentAnalyzeInput>(DataPath, hasHeader: true, separatorChar: ',');
        
        //Step 2: Split data to train-test data
        DataOperationsCatalog.TrainTestData trainTestSplit = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
        IDataView trainingData = trainTestSplit.TrainSet;
        IDataView testData = trainTestSplit.TestSet;
        
        //Step 3: Common data process configuration with pipeline data transformations + choose and set the training algorithm
        var estimator = mlContext.Transforms.Text.FeaturizeText(outputColumnName: "Features", inputColumnName: nameof(SentimentAnalyzeInput.Message))
            .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features"));
        
        //Step 4: Train the model
        var model = estimator.Fit(trainingData);

        #region Advanced: Evaulating the model to see its accuracy and save/persist the trained model to a .ZIP file and use it (like a cache).

        //* Evaluate the model and show accuracy stats
        var predictions = model.Transform(testData);
        var metrics = mlContext.BinaryClassification.Evaluate(data: predictions, labelColumnName: "Label", scoreColumnName: "Score");
        var accuracy = metrics.Accuracy; // 0.97 for our test model.
        
        //* Save/persist the trained model to a .ZIP file.
        mlContext.Model.Save(model, trainingData.Schema, ModelPath);

        #endregion
        
        //Step 5: Predict
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
        //1 -> spam / 0 -> ham (for Prediction column)
        return result is { Prediction: true, Probability: >= 0.5f };
    }
}