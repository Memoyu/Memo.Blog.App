using Masa.Blazor;
using Memo.Blog.App.Models.App;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Layout
{
    public partial class MainLayout
    {
        protected readonly List<NavigationItem> NavigationItems = [
            new("首页", "mdi-notebook-outline", "mdi-notebook", ""),
            new("文章", "mdi-clock-outline", "mdi-clock", "article"),
            new("动态", "mdi-file-outline", "mdi-file", "moment"),
            new("我的",  "mdi-account-outline", "mdi-account", "mine"),
        ];

        [Inject]
        protected NavigationManager NavigationManager { get; set; } = default!;

        protected IEnumerable<string> permanentPaths = [];

        protected bool IsPermanentPath => permanentPaths.Any(it => it == NavigationManager.GetAbsolutePath());

        protected override void OnInitialized()
        {
            base.OnInitialized();
            permanentPaths = NavigationItems.Select(it => NavigationManager.ToAbsoluteUri(it.Path).AbsolutePath).ToList();
        }
    }
}
