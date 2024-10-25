using Memo.Blog.App.Extensions;
using Memo.Blog.App.Models.FileStorage;
using Memo.Blog.App.Utils;

namespace Memo.Blog.App.Services;

public class FileStorageService(IPopupService popupService, IHttpClientFactory httpClientFactory, AppHttpClient appHttpClient)
{
    public async Task<QiniuUploadTokenResult> QiniuTokenGetAsync(string path)
    {
        return await appHttpClient.GetAsync<QiniuUploadTokenResult>("admin/filestorage/qiniu/generate", new { Path = path })
            ?? throw new ApplicationException("获取七牛云Token异常");
    }

    public async Task<string> QiniuUploadAsync(string filePath, string directory)
    {
        if (!File.Exists(filePath)) throw new FileNotFoundException("文件不存在！");

        var qiniuPath = PathUtil.BuildFileStoragPath(filePath, directory);

        var tokenResult = await QiniuTokenGetAsync(qiniuPath)
            ?? throw new FileNotFoundException("获取七牛云授权失败！");

        using FileStream stream = File.OpenRead(filePath);

        var httpClient = httpClientFactory.CreateClient();

        using (var content = new MultipartFormDataContent())
        {
            content.Add(new StringContent(qiniuPath), "key");
            content.Add(new StringContent(tokenResult.Token), "token");
            content.Add(new StreamContent(stream), "file", Path.GetFileName(qiniuPath));

            var response = await httpClient.PostAsync("https://up-z2.qiniup.com", content);//post请求
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            var result = json.ToDesJson<QiniuUploadResult>() ?? throw new ApplicationException("文件上传七牛云异常！");

            // 返回链接
            return tokenResult.Host + result.Key;
        }

        throw new Exception();
    }
}
