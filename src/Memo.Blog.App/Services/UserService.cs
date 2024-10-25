using Masa.Blazor;
using Memo.Blog.App.Common;
using Memo.Blog.App.Models.User;
using Memo.Blog.App.Services.App;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Memo.Blog.App.Services;

public class UserService(IPopupService popupService, AppIntegrationService appIntegrationService, AppHttpClient appHttpClient)
{
    public async Task<ClaimsPrincipal> LoginAsync(string username, string password)
    {
        var claimPrincipal = new ClaimsPrincipal();

        try
        {
            var token = await appHttpClient.PostAnonymousAsync<TokenGenerateResult>("admin/Tokens/generate", new TokenGenerateRequest(username, password)) ?? throw new ApplicationException("登录出现错误");
            
            await appIntegrationService.SetCacheAsync(Const.TOKEN_CACHE_KEY, token);

            claimPrincipal = CreateClaimsPrincipalFromToken(token.AccessToken);
        }
        catch (Exception ex)
        {
            await popupService.Error(ex.Message);
        }

        return claimPrincipal;
    }

    public Task LogoutAsync()
    {
        return appIntegrationService.RemoveCacheAsync(Const.TOKEN_CACHE_KEY);
    }

    public async Task<ClaimsPrincipal?> GetAuthenticatedUserAsync()
    {
        var jwtToken = await appIntegrationService.GetCacheAsync<TokenGenerateResult?>(Const.TOKEN_CACHE_KEY, null);
        if (jwtToken is not null)
        {
            if (jwtToken.ExpiredAt > DateTime.UtcNow)
            {
                return CreateClaimsPrincipalFromToken(jwtToken.AccessToken);
            }

            await popupService.Error("登录过期，请重新登录");
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
