namespace Memo.Blog.App.Services.App;

public partial class AppIntegrationService
{
    /// <summary>
    /// 复制到粘贴板
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public Task SetClipboardAsync(string text) => Clipboard.Default.SetTextAsync(text);

    /// <summary>
    /// 获取粘贴板内容
    /// </summary>
    /// <returns></returns>
    public Task GetClipboardAsync() => Clipboard.Default.GetTextAsync();
}
