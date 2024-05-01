using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace SentimentAnalysisDemo.Web;

[Dependency(ReplaceServices = true)]
public class SentimentAnalysisDemoBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "SentimentAnalysisDemo";
}
