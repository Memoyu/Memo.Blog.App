using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Base;

public class VisibilityComponentBase : ComponentBase, IAsyncDisposable
{
    [Parameter] public virtual bool Visible { get; set; }

    [Parameter] public EventCallback<bool> VisibleChanged { get; set; }

    protected virtual async Task InternalVisibleChanged(bool value)
    {
        Visible = value;

        if (VisibleChanged.HasDelegate)
        {
            await VisibleChanged.InvokeAsync(value);
        }
    }

    public async ValueTask DisposeAsync()
    {
        await Task.CompletedTask;
    }

}
