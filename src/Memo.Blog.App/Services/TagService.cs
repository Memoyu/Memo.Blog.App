using CommunityToolkit.Maui.Core;
using Memo.Blog.App.Models.Article;

namespace Memo.Blog.App.Services;

public class TagService(IPopupService popupService, AppHttpClient appHttpClient)
{
    public async Task<List<TagResult>> ArticleTagListAsync(string name = "")
    {
        return await appHttpClient.GetAsync<List<TagResult>>("admin/tag/list", new { Name = name })
            ?? throw new ApplicationException("获取文章标签列表异常");
    }
}
