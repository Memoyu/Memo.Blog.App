using CommunityToolkit.Maui.Storage;
using Microsoft.Extensions.Logging;

namespace Memo.Blog.App.Services.App;

public class AppFileService
{
    private string CacheDirectory => FileSystem.Current.CacheDirectory;

    private readonly ILogger _logger;
    private readonly HttpClient _httpClient;

    public AppFileService(ILogger<AppFileService> logger)
    {
        _logger = logger;
        _httpClient = new HttpClient();
    }

    public async Task<bool> SaveFileAsync(string url)
    {
        if (string.IsNullOrEmpty(url)) return false;

        try
        {
            using Stream stream = await _httpClient.GetStreamAsync(url);
            var fileName = Path.GetFileName(url);
            FileSaverResult? fileSaverResult = await FileSaver.Default.SaveAsync(fileName, stream, default);
            return fileSaverResult.IsSuccessful;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "DownloadFile fail");
            return false;
        }
    }


    public async Task<string> CreateTempFileAsync(string fileName, Stream stream)
    {
        string path = Path.Combine(CacheDirectory, fileName);
        using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
            await stream.CopyToAsync(fileStream);
        }
        return path;
    }
}
