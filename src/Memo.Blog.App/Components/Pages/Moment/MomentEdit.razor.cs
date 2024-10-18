using Masa.Blazor;
using Masa.Blazor.Presets;
using Memo.Blog.App.Models.App;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Memo.Blog.App.Components.Pages.Moment;

public partial class MomentEdit
{
    [Parameter] public string? Id { get; set; }

    [Inject] PageStackNavController NavController { get; set; } = default!;
    [Inject] NavigationManager NavigationManager { get; set; } = default!;
    [Inject] IJSRuntime JSRuntime { get; set; } = default!;
    [Inject] IPopupService PopupService { get; set; } = default!;

    List<SheetItem> _shareSheetItems = [];
    List<SheetItem> _configSheetItems = [];

    protected override void OnInitialized()
    {
        base.OnInitialized();

        InitData();
    }

    private void InitData()
    {
        _shareSheetItems = [
            new(this,"微信",  "$wechat", ShareToWeChat, "#07c160" ),
            new(this,"复制链接","mdi-link-variant", CopyLink),
        ];

        _configSheetItems = [
            new(this,"置顶",  "mdi-format-vertical-align-top", ShareToWeChat),
            new(this,"评论","mdi-comment-check-outline", CopyLink),
            new(this,"公开","mdi-eye-outline", CopyLink),
        ];
    }

    private void ShareToWeChat()
    {
    }

    private void CopyLink()
    {
        _ = JSRuntime.InvokeVoidAsync(JsInteropConstants.CopyText, NavigationManager.Uri);
        _ = PopupService.EnqueueSnackbarAsync("Link has been copied to clipboard.");
    }
}
