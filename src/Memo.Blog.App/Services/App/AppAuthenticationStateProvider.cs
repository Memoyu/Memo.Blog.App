using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Memo.Blog.App.Services.App;

public class AppAuthenticationStateProvider(UserService userService) : AuthenticationStateProvider
{
    private ClaimsPrincipal _currentUser = new(new ClaimsIdentity());

    public async Task<AuthenticationState> LoginAsync(string username, string password)
    {
        var user = await userService.LoginAsync(username, password);
        _currentUser = user;
        var state = new AuthenticationState(_currentUser);
        NotifyAuthenticationStateChanged(Task.FromResult(state));
        return state;
    }

    public async Task LogoutAsync()
    {
        _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
        await userService.LogoutAsync();
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var user = await userService.GetAuthenticatedUserAsync();
        if (user?.Identity?.IsAuthenticated is true)
        {
            return new AuthenticationState(user);
        }

        return new AuthenticationState(new ClaimsPrincipal());
    }

}
