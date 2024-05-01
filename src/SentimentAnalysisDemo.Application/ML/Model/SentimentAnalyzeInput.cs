using Microsoft.ML.Data;

namespace SentimentAnalysisDemo.Web.ML.Model;

public class SentimentAnalyzeInput
{
    [LoadColumn(0), ColumnName("Label")]
    public bool Category { get; set; }

    [LoadColumn(1), ColumnName("Message")]
    public string Message { get; set; }
}