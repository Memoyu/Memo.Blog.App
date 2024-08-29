using Masa.Blazor;
using Memo.Blog.App.Models.App;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Layout.Navigations;

public partial class BottomNavigationItem
{
    [Inject]
    protected NavigationManager NavigationManager { get; set; } = default!;

    [Parameter]
    public NavigationItem Value { get; set; } = default!;

    protected bool Activated => NavigationManager.ToUri().AbsolutePath == NavigationManager.ToAbsoluteUri(Value.Path).AbsolutePath;

    protected string Icon => Activated ? Value.SelectedIcon : Value.Icon;
}
