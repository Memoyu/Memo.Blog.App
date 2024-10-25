namespace Memo.Blog.App.Services.App;

public partial class AppIntegrationService
{
    /// <summary>
    /// 单张图片选取
    /// </summary>
    /// <returns></returns>
    public async Task<string?> PickImageAsync()
    {
        var image = await FilePicker.Default.PickAsync(new PickOptions { FileTypes = FilePickerFileType.Images });

        if (image is null) return null;

        return image.FullPath;
    }

    /// <summary>
    /// 多张图片选取
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<string>?> PickMultipleImageAsync()
    {
        var images = await FilePicker.Default.PickMultipleAsync(new PickOptions { FileTypes = FilePickerFileType.Images });
       
        if (images is null) return null;
        
        return images.Select(it => it.FullPath);
    }
}
