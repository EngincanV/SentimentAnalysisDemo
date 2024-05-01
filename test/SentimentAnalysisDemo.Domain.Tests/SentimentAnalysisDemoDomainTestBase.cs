using Volo.Abp.Modularity;

namespace SentimentAnalysisDemo;

/* Inherit from this class for your domain layer tests. */
public abstract class SentimentAnalysisDemoDomainTestBase<TStartupModule> : SentimentAnalysisDemoTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
