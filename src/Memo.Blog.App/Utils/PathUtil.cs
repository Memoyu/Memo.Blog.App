namespace Memo.Blog.App.Utils;

public class PathUtil
{
    public static string BuildFileStoragPath(string filePath, string directory)
    {
        var ext = Path.GetExtension(filePath);
       
        return directory + "/" + Guid.NewGuid() + ext;
    }
}
