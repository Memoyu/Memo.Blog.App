using Masa.Blazor;
using Memo.Blog.App.Components.Base;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Components.Image;

public partial class ImagePreview : DialogComponentBase
{
    [Parameter] public string Src { get; set; } = string.Empty;

    [Inject] ImageJsModule Module { get; set; } = default!;
    [Inject] IPopupService PopupService { get; set; } = default!;
    [Inject] public AppFileService AppFileService { get; set; } = default!;

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

    private async Task HandleDownload()
    {
        if (string.IsNullOrEmpty(Src))
        {
            await PopupService.Error("图片不存在！");
            return;
        }

        if (await AppFileService.SaveFileAsync(Src))
            await PopupService.Success("图片已保存至本地");
        else
            await PopupService.Error("图片保存失败！");     
    }
}
