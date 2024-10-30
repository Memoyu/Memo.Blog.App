using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Memo.Blog.App.Models.User;
using Masa.Blazor.Presets;

namespace Memo.Blog.App.Components.Pages.User;

public partial class User
{
    [Inject] PageStackNavController NavController { get; set; } = default!;
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
}
