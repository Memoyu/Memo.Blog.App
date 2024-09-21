using Masa.Blazor;
using Memo.Blog.App.Models.User;
using Memo.Blog.App.Services.App;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Memo.Blog.App.Services;

public class UserService(IPopupService popupService, AppIntegrationService appIntegrationService, AppHttpClient appHttpClient)
{
    private const string TOKEN_CACHE_KEY = "user_token";

    public async Task<ClaimsPrincipal> LoginAsync(string username, string password)
    {
        var token = await appHttpClient.GetAsync<TokenGenerateResult>("tokens/generate", new TokenGenerateRequest(username, password));

        await appIntegrationService.SetCacheAsync(TOKEN_CACHE_KEY, token);
         
        var claimPrincipal = CreateClaimsPrincipalFromToken(token.AccessToken);

        return claimPrincipal;
    }

    public async Task<ClaimsPrincipal?> GetAuthenticatedUserAsync()
    {
        var jwtToken = await appIntegrationService.GetCacheAsync<TokenGenerateResult?>(TOKEN_CACHE_KEY, null);
        if (jwtToken is not null)
        {
            if (jwtToken.ExpiredAt > DateTime.UtcNow)
            {
                return CreateClaimsPrincipalFromToken(jwtToken.AccessToken);
            }

            await popupService.EnqueueSnackbarAsync("登录过期", "请重新登录", AlertTypes.Error);
        }

        return null;
    }

    private ClaimsPrincipal CreateClaimsPrincipalFromToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var identity = new ClaimsIdentity();

        if (tokenHandler.CanReadToken(token))
        {
            var jwtSecurityToken = tokenHandler.ReadJwtToken(token);
            identity = new ClaimsIdentity(jwtSecurityToken.Claims, "Bearer");
        }

        return new ClaimsPrincipal(identity);
    }
}
