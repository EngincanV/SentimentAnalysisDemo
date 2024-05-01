using System;
using System.Collections.Generic;
using System.Text;
using SentimentAnalysisDemo.Localization;
using Volo.Abp.Application.Services;

namespace SentimentAnalysisDemo;

/* Inherit your application services from this class.
 */
public abstract class SentimentAnalysisDemoAppService : ApplicationService
{
    protected SentimentAnalysisDemoAppService()
    {
        LocalizationResource = typeof(SentimentAnalysisDemoResource);
    }
}
