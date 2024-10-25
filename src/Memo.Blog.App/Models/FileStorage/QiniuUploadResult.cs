namespace Memo.Blog.App.Models.FileStorage;

public record QiniuUploadResult
{
    public string Hash { get; set; } = string.Empty;

    public string Key { get; set; } = string.Empty;
}
