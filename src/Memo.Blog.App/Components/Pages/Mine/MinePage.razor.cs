using Microsoft.AspNetCore.Components.Authorization;
using Masa.Blazor;
using Memo.Blog.App.Services.App;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Pages.Mine;

public partial class MinePage
{
    [Inject]
    protected IPopupService PopupService { get; set; } = default!;

    [Inject]
    protected AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;

    private async Task LogoutAsync()
    {
        var confirmed = await PopupService.ConfirmAsync("退出登录", "你确定要退出登录吗？", AlertTypes.Warning);
        if (confirmed)
        {
           await ((AppAuthenticationStateProvider)AuthenticationStateProvider).Logout();
        }
    }
}
