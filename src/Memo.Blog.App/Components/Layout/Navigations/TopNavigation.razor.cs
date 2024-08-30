using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Memo.Blog.App.Components.Layout.Navigations;

public partial class TopNavigation
{
    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public EventCallback<MouseEventArgs>? OnClick { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Inject]
    protected IJSRuntime JS { get; set; } = default!;

    private async Task HandleNavigateToBackClick(MouseEventArgs e)
    {
        if (OnClick == null)
        {
            await JS.InvokeVoidAsync("history.back");
            return;
        }

        await OnClick.Value.InvokeAsync(e);
    }
}
