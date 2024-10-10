using Memo.Blog.App.Models.Article;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Pages.Home.Components.Article;

public partial class ArticleList
{
    [Parameter] public List<PageArticleResult> Articles { get; set; } = [];
}
