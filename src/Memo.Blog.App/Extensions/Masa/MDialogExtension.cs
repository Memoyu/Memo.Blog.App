using Masa.Blazor;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Extensions.Masa;

public class MDialogExtension : MDialog
{
    [Parameter]
    public bool Visible
    {
        get => base.Value;
        set => SetValue(value);
    }

    [Parameter]
    public EventCallback<bool> VisibleChanged
    {
        get => base.ValueChanged;
        set => base.ValueChanged = value;
    }

    [Parameter] public EventCallback<bool> OnAfterShowContent { get; set; }

    [Parameter] public EventCallback OnBeforeShowContent { get; set; }


    protected override void OnInitialized()
    {
        base.OnInitialized();

        AfterShowContent = HandleOnAfterShowContent;
        BeforeShowContent = HandleOnBeforeShowContent;
    }

    private void SetValue(bool value)
    {
        if (base.Value == value)
        {
            return;
        }

        base.Value = value;
    }

    private async Task HandleOnAfterShowContent(bool value)
    {
        if (OnAfterShowContent.HasDelegate)
        {
            await OnAfterShowContent.InvokeAsync(value);
        }
    }

    private async Task HandleOnBeforeShowContent()
    {
        if (OnBeforeShowContent.HasDelegate)
        {
            await OnBeforeShowContent.InvokeAsync();
        }
    }
}

