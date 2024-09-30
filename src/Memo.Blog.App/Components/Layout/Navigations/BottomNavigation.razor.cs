using Masa.Blazor;
using Memo.Blog.App.Models.App;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Layout.Navigations;

public partial class BottomNavigation
{
    private StringNumber? _current = 0;

    [Parameter]
    public List<NavigationItem> Items { get; set; } = [];

    [Inject]
    protected NavigationManager NavigationManager { get; set; } = default!;

}
