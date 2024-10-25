using Masa.Blazor;
using Memo.Blog.App.Models;
using Memo.Blog.App.Models.Article;

namespace Memo.Blog.App.Services;

public class ArticleService(IPopupService popupService, AppHttpClient appHttpClient)
{
    public async Task<PaginationResult<PageArticleResult>> ArticlePageAsync(PageArticleQuery query)
    {
        var data = new PaginationResult<PageArticleResult>();
        try
        {
            data = await appHttpClient.GetAsync<PaginationResult<PageArticleResult>>("admin/article/page", query)
                ?? throw new ApplicationException("获取文章列表异常");
        }
        catch (Exception ex)
        {
            await popupService.Error("服务器异常", ex.Message);
        }

        return data;
    }

    public async Task<ArticleResult> ArticleGetAsync(string id)
    {
        return await appHttpClient.GetAsync<ArticleResult>("admin/article/get", new { ArticleId = id })
            ?? throw new ApplicationException("获取文章详情异常");
    }
}
