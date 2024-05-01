using Microsoft.AspNetCore.Builder;
using SentimentAnalysisDemo;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<SentimentAnalysisDemoWebTestModule>();

public partial class Program
{
}
