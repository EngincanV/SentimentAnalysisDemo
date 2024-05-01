using SentimentAnalysisDemo.Samples;
using Xunit;

namespace SentimentAnalysisDemo.MongoDB.Domains;

[Collection(SentimentAnalysisDemoTestConsts.CollectionDefinitionName)]
public class MongoDBSampleDomainTests : SampleDomainTests<SentimentAnalysisDemoMongoDbTestModule>
{

}
