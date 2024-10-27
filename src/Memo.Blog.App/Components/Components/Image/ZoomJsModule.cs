using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Memo.Blog.App.Components.Components.Image;

public class ZoomJsModule : JsModuleExtension
{
    public ZoomJsModule(IJSRuntime js) : base(js, "js/zoom-helper.js")
    {
    }

    public async Task InitPanZoom(ElementReference element)
    {
        await base.InvokeVoidAsync("initPanZoom", element);
    }

    public async Task Reset(ElementReference element)
    {
        await base.InvokeVoidAsync("reset", element);
    }
}
