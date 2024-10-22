using Memo.Blog.App.Components.Base;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Components.Image;

public partial class ImagePreview : DialogComponentBase
{
    [Parameter] public string Src { get; set; } = string.Empty;

    [Inject] ImageJsModule Module { get; set; } = default!;

    bool isInitialized;
    ElementReference _previewImg;

    protected override async Task InternalVisibleChanged(bool value)
    {
        await Module.Reset(_previewImg);
        await base.InternalVisibleChanged(value);
    }

    private async Task BeforeShowContent()
    {
        if (!isInitialized)
        {
            await Module.InitPanZoom(_previewImg);
            isInitialized = true;
        }
    }

    private async Task HandleReset()
    {
        await Module.Reset(_previewImg);
    }

    private void HandleDownload()
    {
       
    }
}
