using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SentimentAnalysisDemo.Data;

/* This is used if database provider does't define
 * ISentimentAnalysisDemoDbSchemaMigrator implementation.
 */
public class NullSentimentAnalysisDemoDbSchemaMigrator : ISentimentAnalysisDemoDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
