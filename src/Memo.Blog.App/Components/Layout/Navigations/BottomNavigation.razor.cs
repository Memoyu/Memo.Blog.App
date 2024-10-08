using Masa.Blazor;
using Memo.Blog.App.Models.App;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Layout.Navigations;

public partial class BottomNavigation
{
    private StringNumber? _current = 0;

    private readonly List<NavigationItem> navItems = [
            new(0, "首页", "mdi-notebook-outline", "mdi-notebook", ""),
            new(1, "文章", "mdi-clock-outline", "mdi-clock", "article"),
            new(2, "动态", "mdi-file-outline", "mdi-file", "moment"),
            new(3, "我的",  "mdi-account-outline", "mdi-account", "user"),
    ];

    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

}
