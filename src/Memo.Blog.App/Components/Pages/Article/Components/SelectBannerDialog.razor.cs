using Memo.Blog.App.Components.Base;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Pages.Article.Components;

public partial class SelectBannerDialog : DialogComponentBase
{
    [Parameter] public string Banner { get; set; } = string.Empty;
    [Parameter] public EventCallback<string> BannerChanged { get; set; }

    [Inject] IPopupService PopupService { get; set; } = default!;
    [Inject] AppIntegrationService AppIntegrationService { get; set; } = default!;
    [Inject] FileStorageService FileStorageService { get; set; } = default!;

    bool _preview = false;

    private async Task BeforeShowContent()
    {
    }

    private async Task HandlePickImage()
    {
        var path = await AppIntegrationService.PickImageAsync();
        if (string.IsNullOrWhiteSpace(path)) return;

        try
        {
            var url = await FileStorageService.QiniuUploadAsync(path, Const.FILE_STORAGE_ARTICLE_BANNER_KEY);
            Banner = url;

        }
        catch (Exception ex)
        {
            await PopupService.Error(ex.Message);
        }

    }

    private async Task HandleSave()
    {
    }
}
