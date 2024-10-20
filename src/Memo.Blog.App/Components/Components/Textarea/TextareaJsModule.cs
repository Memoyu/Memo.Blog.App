using Memo.Blog.App.Extensions.Masa;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Memo.Blog.App.Components.Components.Textarea;

public class TextareaJsModule : JsModuleExtension
{
    public TextareaJsModule(IJSRuntime js) : base(js, "js/mtextarea-helper.js")
    {
    }

    public ValueTask<string?> InsertText(ElementReference element, string value)
    {
        return base.InvokeAsync<string?>("insertText", [element, value]);
    }
}
