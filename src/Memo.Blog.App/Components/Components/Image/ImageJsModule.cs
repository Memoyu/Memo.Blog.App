using Memo.Blog.App.Extensions.Masa;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Memo.Blog.App.Components.Components.Image;

public class ImageJsModule : JsModuleExtension
{
    public ImageJsModule(IJSRuntime js) : base(js, "js/image-helper.js")
    {
    }

    public async Task ImgDragAndDrop(ElementReference element)
    {
        await base.InvokeVoidAsync("imgDragAndDrop", element);
    }

    public async Task Destroy(ElementReference element)
    {
        await base.InvokeVoidAsync("destroy", element);
    }

    public ValueTask<string?> GetStyle(ElementReference element, string styleProp)
    {
        return base.InvokeAsync<string?>("getStyle", [element, styleProp]);
    }
}
