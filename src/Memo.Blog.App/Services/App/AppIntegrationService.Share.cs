namespace Memo.Blog.App.Services.App;

public partial class AppIntegrationService
{
    /// <summary>
    /// 分享文件
    /// </summary>
    /// <param name="title"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public Task ShareFileAsync(string title, string path)
    {
        if (!File.Exists(path)) return Task.CompletedTask;

        return Share.Default.RequestAsync(new ShareFileRequest
        {
            Title = title,
            File = new ShareFile(path)
        });
    }

    /// <summary>
    /// 分享文本
    /// </summary>
    /// <param name="title"></param>
    /// <param name="text"></param>
    /// <returns></returns>
    public Task ShareTextAsync(string title, string text)
    {
        if (string.IsNullOrEmpty(text)) return Task.CompletedTask;

        return Share.Default.RequestAsync(new ShareTextRequest
        {
            Title = title,
            Text = text
        });
    }
}
