using Masa.Blazor;
using Memo.Blog.App.Models;
using Memo.Blog.App.Models.Moment;

namespace Memo.Blog.App.Services;

public class MomentService(IPopupService popupService, AppHttpClient appHttpClient)
{
    public async Task<PaginationResult<MomentResult>> MomentPageAsync(PageMomentQuery query)
    {
        var data = new PaginationResult<MomentResult>();
        try
        {
            data = await appHttpClient.GetAsync<PaginationResult<MomentResult>>(
            "admin/moment/page",
            query) ?? throw new ApplicationException("获取动态列表异常");
        }
        catch (Exception ex)
        {
            await popupService.EnqueueSnackbarAsync("服务器异常", ex.Message, AlertTypes.Error);
        }

        return data;
    }
}
