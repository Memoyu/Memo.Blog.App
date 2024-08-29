using Masa.Blazor;
using Memo.Blog.App.Models.App;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Layout.Navigations;

public partial class BottomNavigation
{
    [Parameter]
    public List<NavigationItem> Items { get; set; } = [];

    [Inject]
    protected NavigationManager NavigationManager { get; set; } = default!;


    [Parameter]
    public bool IsPermanentPath { get; set; }

    protected bool Show => IsPermanentPath;

}
