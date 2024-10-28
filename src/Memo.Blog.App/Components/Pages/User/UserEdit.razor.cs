using Memo.Blog.App.Models.User;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Pages.User;

public partial class UserEdit
{
    [Inject] AppAuthenticationStateProvider AppAuthenticationStateProvider { get; set; } = default!;
    [Inject] AppIntegrationService AppIntegrationService { get; set; } = default!;

    UserResult _user;

    protected override Task OnInitializedAsync()
    {
        _user = AppIntegrationService.GetUser();
        return base.OnInitializedAsync();
    }

    private async Task HandelLogout()
    {
        await AppAuthenticationStateProvider.LogoutAsync();
    }
}
