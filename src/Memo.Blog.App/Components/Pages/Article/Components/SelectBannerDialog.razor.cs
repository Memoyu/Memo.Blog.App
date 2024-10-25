using Memo.Blog.App.Components.Base;
using Memo.Blog.App.Models.FileStorage;
using Memo.Blog.App.Utils;
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

        var qiniuPath = PathUtil.BuildFileStoragPath(path, FileStoragPathType.ArticlesBanner);
        var result = await FileStorageService.QiniuUploadAsync(path, qiniuPath);
    }

    private async Task HandleSave()
    {
    }
}
