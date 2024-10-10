using Masa.Blazor;
using Memo.Blog.App.Models.App;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Layout.Navigations;

public partial class BottomNavigation
{
    private StringNumber current = "";
    private string selected = string.Empty;

    private List<NavigationItem> navItems = [
            new( "首页", "mdi-view-dashboard-outline", "mdi-view-dashboard", ""),
            new( "Todo", "mdi-check", "mdi-check-bold", "todo"),
            new( "我的",  "mdi-account-outline", "mdi-account", "user"),
    ];

    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    private void ValueChanged(StringNumber value)
    {
        selected = value.ToString() ?? string.Empty;
    }
}
