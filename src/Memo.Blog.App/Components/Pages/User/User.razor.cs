using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Memo.Blog.App.Models.User;

namespace Memo.Blog.App.Components.Pages.User;

public partial class User
{
    [Inject] IPopupService PopupService { get; set; } = default!;
    [Inject] AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;
    [Inject] AppIntegrationService AppIntegrationService { get; set; } = default!;
    [Inject] MasaBlazor MasaBlazor { get; set; } = default!;

    UserResult _user;

    protected override Task OnInitializedAsync()
    {
        _user = AppIntegrationService.GetUser();
        return base.OnInitializedAsync();
    }

    private async Task LogoutAsync()
    {
        var confirmed = await PopupService.ConfirmAsync("退出登录", "你确定要退出登录吗？", AlertTypes.Warning);
        if (confirmed)
        {
            await ((AppAuthenticationStateProvider)AuthenticationStateProvider).LogoutAsync();
        }
    }
}
