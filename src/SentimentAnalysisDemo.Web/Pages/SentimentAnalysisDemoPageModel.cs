using SentimentAnalysisDemo.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace SentimentAnalysisDemo.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class SentimentAnalysisDemoPageModel : AbpPageModel
{
    protected SentimentAnalysisDemoPageModel()
    {
        LocalizationResourceType = typeof(SentimentAnalysisDemoResource);
    }
}
