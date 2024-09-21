using Memo.Blog.App.Models.App;
using Microsoft.Extensions.Options;

namespace Memo.Blog.App.Services;

public class AppHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly AppSettings _appSettings;

    public AppHttpClient(HttpClient httpClient, IOptions<AppSettings> options)
    {
        _appSettings = options.Value;
        httpClient.BaseAddress = new Uri(_appSettings.ApiDomain);

        _httpClient = httpClient;
    }

    public async Task<TResult> GetAsync<TResult>(string url, object req, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<TResult> PostAsync<TResult>(string url, object req, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
