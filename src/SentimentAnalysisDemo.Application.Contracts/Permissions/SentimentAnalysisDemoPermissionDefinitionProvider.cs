using SentimentAnalysisDemo.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SentimentAnalysisDemo.Permissions;

public class SentimentAnalysisDemoPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SentimentAnalysisDemoPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(SentimentAnalysisDemoPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SentimentAnalysisDemoResource>(name);
    }
}
