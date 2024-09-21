using Memo.Blog.App.Services.App;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Diagnostics.CodeAnalysis;

namespace Memo.Blog.App.Components.Pages.Login;

public partial class LoginPage
{
    private string? _username;
    private string? _password;

    private bool _loggingIn;

    [MemberNotNullWhen(false, nameof(_username), nameof(_password))]
    private bool LoginBtnDisabled => string.IsNullOrWhiteSpace(_username) || string.IsNullOrWhiteSpace(_password);

    [Inject]
    protected NavigationManager NavigationManager { get; set; } = default!;

    [Inject]
    protected AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;

    private async Task LogInAsync()
    {
        if (LoginBtnDisabled)
        {
            return;
        }

        _loggingIn = true;
        StateHasChanged();

        var authenticationState = await ((AppAuthenticationStateProvider)AuthenticationStateProvider).LoginAsync(_username, _password);
        if (authenticationState.User.Identity?.IsAuthenticated is true)
        {
            NavigationManager.NavigateTo("/");
        }

        _loggingIn = false;
    }
}
