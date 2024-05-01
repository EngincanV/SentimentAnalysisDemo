using Volo.Abp.Settings;

namespace SentimentAnalysisDemo.Settings;

public class SentimentAnalysisDemoSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(SentimentAnalysisDemoSettings.MySetting1));
    }
}
