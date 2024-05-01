using Volo.Abp.Modularity;

namespace SentimentAnalysisDemo;

[DependsOn(
    typeof(SentimentAnalysisDemoDomainModule),
    typeof(SentimentAnalysisDemoTestBaseModule)
)]
public class SentimentAnalysisDemoDomainTestModule : AbpModule
{

}
