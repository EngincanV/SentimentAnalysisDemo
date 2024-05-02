using Microsoft.ML.Data;

namespace SentimentAnalysisDemo.ML.Model;

public class SentimentAnalyzeResult
{
    [ColumnName("PredictedLabel")]
    public bool Prediction { get; set; }

    public float Probability { get; set; }

    public float Score { get; set; }
}