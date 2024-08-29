using Masa.Blazor;
using Memo.Blog.App.Models.App;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Layout.Navigations;

public partial class BottomNavigation
{
    protected readonly List<NavigationItem> navigationItems = [
        new("首页", "mdi-notebook-outline", "mdi-notebook", ""),
        new("文章", "mdi-clock-outline", "mdi-clock", "article"),
        new("动态", "mdi-file-outline", "mdi-file", "moment"),
        new("我的",  "mdi-account-outline", "mdi-account", "mine"),
    ];

    [Inject]
    protected NavigationManager NavigationManager { get; set; } = default!;

    protected bool IsPermanentPath
            => navigationItems.Any(it => NavigationManager.ToAbsoluteUri(it.Path).AbsolutePath == NavigationManager.GetAbsolutePath());

    protected bool Show => IsPermanentPath;

    protected override void OnInitialized()
    {
        base.OnInitialized();

    }
}
