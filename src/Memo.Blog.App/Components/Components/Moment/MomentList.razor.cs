using Memo.Blog.App.Models.App;
using System.Diagnostics;

namespace Memo.Blog.App.Components.Components.Moment;

public partial class MomentList
{
    private List<SummaryCardItem> momentSummaries =
    [
        new SummaryCardItem ("动态数", "0"),
        new SummaryCardItem ("评论数", "0"),
        new SummaryCardItem ("浏览数", "0")
    ];

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            Trace.WriteLine("动态第一次加载");
            await Task.Delay(1000);
            momentSummaries =
            [
                new SummaryCardItem ("动态数", "10"),
                new SummaryCardItem ("评论数", "20"),
                new SummaryCardItem ("浏览数", "30")
            ];
            // StateHasChanged();
        }
    }
}
