using System.Threading.Tasks;

namespace SentimentAnalysisDemo.ML;

public interface ISpamDetector
{
    Task CheckAsync(string text);
}