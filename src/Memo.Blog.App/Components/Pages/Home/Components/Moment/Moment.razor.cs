using Masa.Blazor;
using Memo.Blog.App.Models.App;
using Memo.Blog.App.Models.Moment;
using Memo.Blog.App.Services;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace Memo.Blog.App.Components.Pages.Home.Components.Moment;

public partial class Moment
{
    private List<SummaryCardItem> _summaries = [
      new SummaryCardItem ("动态", "0"),
        new SummaryCardItem ("评论", "0"),
        new SummaryCardItem ("浏览", "0"),
    ];

    private List<MomentResult> _moments = [];
    private int _page = 1;
    private int _pageSize = 10;
    private MInfiniteScroll? _infiniteScroll;

    [Inject]
    protected MomentService MomentService { get; set; } = default!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            Trace.WriteLine("动态第一次加载");
        }
    }

    protected override async Task OnInitializedAsync()
    {


        await base.OnInitializedAsync();
    }

    private async Task HandleOnLoadAsync(InfiniteScrollLoadEventArgs args)
    {
        // TODO： 获取动态汇总数据，现为模拟数据赋值，后期替换
        await Task.Delay(1000);
        _summaries[0].Value = "100";
        _summaries[1].Value = "30";
        _summaries[2].Value = "80";

        var isFirstLoad = _page == 1;

        var page = await MomentService.MomentPageAsync(new PageMomentQuery
        {
            Page = _page++,
            Size = _pageSize,
        });
        var appendMoments = page.Items;

        if (isFirstLoad)
        {
            _moments = appendMoments;
            _page++;
        }
        else
        {
            _moments.AddRange(appendMoments);
        }

        args.Status = appendMoments.Count < page.Total ? InfiniteScrollLoadStatus.Empty : InfiniteScrollLoadStatus.Ok;
    }

    private async Task HandleOnRefreshAsync()
    {
        _page = 1;

        if (_infiniteScroll != null)
        {
            await _infiniteScroll.ResetAsync();
        }
    }

}
