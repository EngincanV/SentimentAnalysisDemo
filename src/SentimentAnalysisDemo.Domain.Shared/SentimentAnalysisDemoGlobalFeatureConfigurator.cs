using Volo.Abp.GlobalFeatures;
using Volo.Abp.Threading;

namespace SentimentAnalysisDemo;

public static class SentimentAnalysisDemoGlobalFeatureConfigurator
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        OneTimeRunner.Run(() =>
        {
            GlobalFeatureManager.Instance.Modules.CmsKit(cmsKit =>
            {
                cmsKit.Comments.Enable();
            });
        });
    }
}
