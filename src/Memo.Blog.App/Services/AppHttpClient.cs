using Memo.Blog.App.Common;
using Memo.Blog.App.Extensions;
using Memo.Blog.App.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Memo.Blog.App.Services;

public class AppHttpClient
{
    private readonly HttpClient _httpClient;

    public AppHttpClient(HttpClient httpClient)
    {
        httpClient.BaseAddress = new Uri(Configs.ApiUrl);

        _httpClient = httpClient;
    }

    public async Task<TResult?> GetAsync<TResult>(string url, object? req = null, CancellationToken cancellationToken = default)
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
}
