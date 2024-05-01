using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SentimentAnalysisDemo.ML;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.CmsKit.Comments;
using Volo.CmsKit.Public.Comments;
using Volo.CmsKit.Users;

namespace SentimentAnalysisDemo.Volo.CmsKit.Public.Comments;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(ICommentPublicAppService), typeof(CommentPublicAppService), typeof(MyCommentAppService))]
public class MyCommentAppService : CommentPublicAppService
{
    protected ISpamDetector SpamDetector { get; }
    
    public MyCommentAppService(
        ICommentRepository commentRepository, 
        ICmsUserLookupService cmsUserLookupService, 
        IDistributedEventBus distributedEventBus, 
        CommentManager commentManager, 
        IOptionsSnapshot<CmsKitCommentOptions> cmsCommentOptions,
        ISpamDetector spamDetector
        ) 
        : base(commentRepository, cmsUserLookupService, distributedEventBus, commentManager, cmsCommentOptions)
    {
        SpamDetector = spamDetector;
    }

    public override async Task<CommentDto> CreateAsync(string entityType, string entityId, CreateCommentInput input)
    {
        //Check message: spam or ham.
        await SpamDetector.CheckAsync(input.Text);
        
        return await base.CreateAsync(entityType, entityId, input);
    }

    public override async Task<CommentDto> UpdateAsync(Guid id, UpdateCommentInput input)
    {
        //Check message: spam or ham.
        await SpamDetector.CheckAsync(input.Text);
        
        return await base.UpdateAsync(id, input);
    }
}