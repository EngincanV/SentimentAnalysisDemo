using Volo.Abp.Modularity;

namespace SentimentAnalysisDemo;

public abstract class SentimentAnalysisDemoApplicationTestBase<TStartupModule> : SentimentAnalysisDemoTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
