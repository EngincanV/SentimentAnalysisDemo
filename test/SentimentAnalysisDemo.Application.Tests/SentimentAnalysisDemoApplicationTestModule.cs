using Volo.Abp.Modularity;

namespace SentimentAnalysisDemo;

[DependsOn(
    typeof(SentimentAnalysisDemoApplicationModule),
    typeof(SentimentAnalysisDemoDomainTestModule)
)]
public class SentimentAnalysisDemoApplicationTestModule : AbpModule
{

}
