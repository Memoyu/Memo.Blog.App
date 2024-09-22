using Microsoft.AspNetCore.Components.Authorization;
using Masa.Blazor;
using Memo.Blog.App.Services.App;

namespace Memo.Blog.App.Components.Pages.Mine;

public partial class MinePage(IPopupService popupService, AuthenticationStateProvider AuthenticationStateProvider)
{
    private async Task LogoutAsync()
    {
        var confirmed = await popupService.ConfirmAsync("退出登录", "你确定要退出登录吗？", AlertTypes.Warning);
        if (confirmed)
        {
            ((AppAuthenticationStateProvider)AuthenticationStateProvider).Logout();
        }
    }
}
