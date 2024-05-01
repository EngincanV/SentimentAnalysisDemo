using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace SentimentAnalysisDemo.MongoDB;

[DependsOn(
    typeof(SentimentAnalysisDemoApplicationTestModule),
    typeof(SentimentAnalysisDemoMongoDbModule)
)]
public class SentimentAnalysisDemoMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = SentimentAnalysisDemoMongoDbFixture.GetRandomConnectionString();
        });
    }
}
