using Masa.Blazor.Presets;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Pages.Article
{
    public partial class ArticleEdit
    {
        [Parameter] public string? Id { get; set; }

        [Inject] protected PageStackNavController NavController { get; set; } = default!;
    }
}
