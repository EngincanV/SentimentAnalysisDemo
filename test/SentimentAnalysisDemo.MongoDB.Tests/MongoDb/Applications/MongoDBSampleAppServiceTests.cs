using SentimentAnalysisDemo.MongoDB;
using SentimentAnalysisDemo.Samples;
using Xunit;

namespace SentimentAnalysisDemo.MongoDb.Applications;

[Collection(SentimentAnalysisDemoTestConsts.CollectionDefinitionName)]
public class MongoDBSampleAppServiceTests : SampleAppServiceTests<SentimentAnalysisDemoMongoDbTestModule>
{

}
