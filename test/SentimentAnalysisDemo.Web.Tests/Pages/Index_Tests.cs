using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace SentimentAnalysisDemo.Pages;

public class Index_Tests : SentimentAnalysisDemoWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
