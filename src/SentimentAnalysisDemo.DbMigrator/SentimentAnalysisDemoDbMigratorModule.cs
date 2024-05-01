using SentimentAnalysisDemo.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace SentimentAnalysisDemo.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SentimentAnalysisDemoMongoDbModule),
    typeof(SentimentAnalysisDemoApplicationContractsModule)
    )]
public class SentimentAnalysisDemoDbMigratorModule : AbpModule
{
}
