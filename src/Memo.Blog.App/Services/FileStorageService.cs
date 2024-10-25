using Memo.Blog.App.Models.FileStorage;

namespace Memo.Blog.App.Services;

public class FileStorageService(IPopupService popupService, IHttpClientFactory httpClientFactory, AppHttpClient appHttpClient)
{
    public async Task<QiniuUploadTokenResult> QiniuTokenGetAsync(string path)
    {
        return await appHttpClient.GetAsync<QiniuUploadTokenResult>("admin/filestorage/qiniu/generate", new { Path = path })
            ?? throw new ApplicationException("获取七牛云Token异常");
    }

    public async Task<QiniuUploadResult> QiniuUploadAsync(string loaclPath, string qiniuPath )
    {
        var tokenResult = await QiniuTokenGetAsync(qiniuPath);

        throw new Exception();
    }
}
