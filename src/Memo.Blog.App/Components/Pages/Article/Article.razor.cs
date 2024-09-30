using Masa.Blazor.Presets;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Pages.Article
{
    public partial class Article
    {

        [Inject]
        protected PageStackNavController NavController { get; set; } = default!;

        private async Task HandleArticleEditClick()
        {
            NavController.Push("/article/edit");
        }
    }
}
