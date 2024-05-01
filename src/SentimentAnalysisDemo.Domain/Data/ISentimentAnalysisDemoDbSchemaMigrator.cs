using System.Threading.Tasks;

namespace SentimentAnalysisDemo.Data;

public interface ISentimentAnalysisDemoDbSchemaMigrator
{
    Task MigrateAsync();
}
