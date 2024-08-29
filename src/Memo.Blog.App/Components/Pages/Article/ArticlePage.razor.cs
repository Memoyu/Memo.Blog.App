using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Pages.Article
{
    public partial class ArticlePage
    {

        [Inject]
        protected NavigationManager NavigationManager { get; set; } = default!;

        private async Task HandleArticleEditClick()
        {
            NavigationManager.NavigateTo("/article/edit");
        }
    }
}
