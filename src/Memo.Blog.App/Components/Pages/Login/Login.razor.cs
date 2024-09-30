using Memo.Blog.App.Services.App;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Diagnostics.CodeAnalysis;

namespace Memo.Blog.App.Components.Pages.Login;

public partial class Login
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

    private async Task VisitorLoginAsync()
    {
        var username = "memoyu";
        var password = "memoyu";
        await LoginAndNavigateToAsync(username, password);
    }

    private async Task LoginAsync()
    {
        if (LoginBtnDisabled)
        {
            return;
        }

        await LoginAndNavigateToAsync(_username, _password);
    }

    private async Task LoginAndNavigateToAsync(string username, string password)
    {
        _loggingIn = true;
        StateHasChanged();

        var authenticationState = await ((AppAuthenticationStateProvider)AuthenticationStateProvider).LoginAsync(username, password);
        if (authenticationState.User.Identity?.IsAuthenticated is true)
        {
            NavigationManager.NavigateTo("/");
        }

        _loggingIn = false;
    }
}
