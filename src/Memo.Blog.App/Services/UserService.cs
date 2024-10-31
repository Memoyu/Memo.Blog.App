using Memo.Blog.App.Models.User;
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
            var userToken = await appHttpClient.PostAnonymousAsync<TokenGenerateResult>("admin/Tokens/generate", new TokenGenerateRequest(username, password)) 
                ?? throw new ApplicationException("登录出现错误");        
            await appIntegrationService.SetCacheAsync(Const.TOKEN_CACHE_KEY, userToken);
            claimPrincipal = await CreateClaimsPrincipalFromToken(userToken);
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
        var userToken = await appIntegrationService.GetCacheAsync<TokenGenerateResult?>(Const.TOKEN_CACHE_KEY, null);
        if (userToken is not null)
        {
            if (userToken.ExpiredAt > DateTime.Now)
            {
                return await CreateClaimsPrincipalFromToken(userToken);
            }

            await popupService.Error("登录过期，请重新登录");
        }

        return null;
    }

    public async Task<UserResult> UserGetAsync()
    {
         return await appHttpClient.GetAsync<UserResult>("admin/user/get")
            ?? throw new ApplicationException("获取用户信息异常");
    }

    private async Task<ClaimsPrincipal> CreateClaimsPrincipalFromToken(TokenGenerateResult userToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var identity = new ClaimsIdentity();

        if (tokenHandler.CanReadToken(userToken.AccessToken))
        {
            var jwtSecurityToken = tokenHandler.ReadJwtToken(userToken.AccessToken);
            identity = new ClaimsIdentity(jwtSecurityToken.Claims, "Bearer");
        }

        var user = await UserGetAsync();
        appIntegrationService.SetUser(user);

        return new ClaimsPrincipal(identity);
    }
}
