﻿using Memo.Blog.App.Extensions.Masa;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Memo.Blog.App.Components.Components.Image;

public class ImageJsModule : JsModuleExtension
{
    public ImageJsModule(IJSRuntime js) : base(js, "js/image-helper.js")
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