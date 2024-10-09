using System.Diagnostics;

namespace Memo.Blog.App.Components.Components.Article;

public partial class ArticleList
{
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            Trace.WriteLine("文章第一次加载");
            await Task.CompletedTask;
        }
    }
}
