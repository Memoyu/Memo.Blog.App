using Masa.Blazor;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Components.Textarea;

public partial class TextareaEdit
{
    [CascadingParameter(Name = "Culture")]
    public string? Culture { get; set; }
    [Parameter] public string? Value { get; set; }
    [Parameter] public EventCallback<string> ValueChanged { get; set; }
    [Parameter] public string? Class { get; set; }
    [Parameter] public bool Autofocus { get; set; }
    [Parameter] public EventCallback OnAfter { get; set; }
    [Inject] private TextareaJsModule Module { get; set; } = default!;

    private MTextarea mTextarea = default!;

    public async Task InsertValueAsync(string value)
    {
        Value = await Module.InsertText(mTextarea.InputElement, value);
        if (ValueChanged.HasDelegate)
        {
            await ValueChanged.InvokeAsync(Value);
        }
    }
}

