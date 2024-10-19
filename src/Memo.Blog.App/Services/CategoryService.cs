using CommunityToolkit.Maui.Core;
using Memo.Blog.App.Models.Article;

namespace Memo.Blog.App.Services;

public class CategoryService(IPopupService popupService, AppHttpClient appHttpClient)
{
    public async Task<List<CategoryResult>> ArticleCategoryListAsync(string name = "")
    {
        return await appHttpClient.GetAsync<List<CategoryResult>>("admin/category/list", new { Name = name })
            ?? throw new ApplicationException("获取文章分类列表异常");
    }
}
