using SentimentAnalysisDemo.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SentimentAnalysisDemo.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class SentimentAnalysisDemoController : AbpControllerBase
{
    protected SentimentAnalysisDemoController()
    {
        LocalizationResource = typeof(SentimentAnalysisDemoResource);
    }
}
