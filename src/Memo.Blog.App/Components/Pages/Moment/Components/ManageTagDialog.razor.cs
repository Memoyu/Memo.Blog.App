using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Memo.Blog.App.Components.Pages.Moment.Components;

public partial class ManageTagDialog
{
    [Parameter] public bool Visible { get; set; }
    [Parameter] public EventCallback<bool> VisibleChanged { get; set; }
    [Parameter] public List<string> Tags { get; set; } = [];
    [Parameter] public EventCallback<List<string>> TagsChanged { get; set; }

    List<string> _internalTags = [];
    bool _showInput;
    string _inputTag = string.Empty;

    private void BeforeShowContent()
    {
        _internalTags = Tags.ToList();
    }

    private void HandleSaveTag()

    {
        if (string.IsNullOrWhiteSpace(_inputTag)) return;
        _internalTags.Add(_inputTag);
        _inputTag = string.Empty;
    }

    private void HandleTagClose(string tag)
    {
        _internalTags.Remove(tag);
    }

    private async Task HandleCancel(MouseEventArgs _)
    {
        await InternalVisibleChanged(false);
    }

    private async Task HandleSave(MouseEventArgs _)
    {
        Tags = _internalTags;
        if (TagsChanged.HasDelegate)
        {
            await TagsChanged.InvokeAsync(_internalTags);
        }

        await InternalVisibleChanged(false);
    }

    protected async Task InternalVisibleChanged(bool value)
    {
        Visible = value;

        if (VisibleChanged.HasDelegate)
        {
            await VisibleChanged.InvokeAsync(value);
        }
    }
}
