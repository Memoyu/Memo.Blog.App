using Memo.Blog.App.Common;
using Memo.Blog.App.Extensions;
using Memo.Blog.App.Models;
using Memo.Blog.App.Models.User;
using Memo.Blog.App.Services.App;
using System.Net.Http.Headers;
using System.Text;

namespace Memo.Blog.App.Services;

public class AppHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly AppIntegrationService _appIntegrationService;

    public AppHttpClient(HttpClient httpClient, AppIntegrationService appIntegrationService)
    {
        httpClient.BaseAddress = new Uri(Configs.ApiUrl);
        httpClient.Timeout = TimeSpan.FromSeconds(60);

        _httpClient = httpClient;
        _appIntegrationService = appIntegrationService;
    }

    public async Task<TResult?> GetAsync<TResult>(string url, object? req = null, CancellationToken cancellationToken = default)
    {
        await EnsureTokenAsync();
        return await InternalGetAsync<TResult>(url, req, cancellationToken);
    }

    public async Task<TResult?> GetAnonymousAsync<TResult>(string url, object? req = null, CancellationToken cancellationToken = default)
    {
        return await InternalGetAsync<TResult>(url, req, cancellationToken);
    }

    public async Task<TResult?> InternalGetAsync<TResult>(string url, object? req = null, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = json.ToDesJson<BaseResult<TResult>>() ?? throw new ApplicationException("请求出现异常，请稍后再试！");
        if (!result.IsSuccess) throw new ApplicationException(result.Message);
        return result.Data;
    }

    public async Task<TResult?> PostAsync<TResult>(string url, object? req = null, CancellationToken cancellationToken = default)
    {
        await EnsureTokenAsync();

        return await InternalPostAsync<TResult>(url, req, cancellationToken);
    }

    public async Task<TResult?> PostAnonymousAsync<TResult>(string url, object? req = null, CancellationToken cancellationToken = default)
    {
        return await InternalPostAsync<TResult>(url, req, cancellationToken);
    }

    private async Task<TResult?> InternalPostAsync<TResult>(string url, object? req = null, CancellationToken cancellationToken = default)
    {

        var reqJson = (req == null ? string.Empty : req.GetType() == typeof(string) ? req.ToString() : req.ToJson()) ?? string.Empty;

        HttpResponseMessage response;
        using (HttpContent httpContent = new StringContent(reqJson, Encoding.UTF8))
        {
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response = await _httpClient.PostAsync(url, httpContent, cancellationToken);
        }

        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync(cancellationToken);

        var result = json.ToDesJson<BaseResult<TResult>>() ?? throw new ApplicationException("请求出现异常，请稍后再试！");
        if (!result.IsSuccess) throw new ApplicationException(result.Message);

        return result.Data;
    }

    private async Task EnsureTokenAsync()
    {
        var token = await _appIntegrationService.GetCacheAsync<TokenGenerateResult?>(Const.TOKEN_CACHE_KEY, null);

        if (token is null || string.IsNullOrWhiteSpace(token.AccessToken))
            throw new ArgumentNullException("认证失败，请重新登录！");

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
    }
}
