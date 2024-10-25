namespace Memo.Blog.App.Utils;

public class PathUtil
{
    public static string BuildFileStoragPath(string localPath, FileStoragPathType type)
    {
        var ext = Path.GetExtension(localPath);
        var path = type switch
        {
            FileStoragPathType.ArticlesBanner => Const.FILE_STORAGE_ARTICLE_BANNER_KEY,
            FileStoragPathType.MomentContent => Const.FILE_STORAGE_MOMEMT_CONTENT_KEY,
            FileStoragPathType.AboutContent => Const.FILE_STORAGE_ABOUNT_CONTENT_KEY,
            FileStoragPathType.AccountAvatar => Const.FILE_STORAGE_ACCOUNT_AVATAR_KEY,
            FileStoragPathType.ConfigBanner => Const.FILE_STORAGE_CONFIG_BANNER_KEY,
            _ => string.Empty,
        };

        return path + Guid.NewGuid() + ext;
    }
}
