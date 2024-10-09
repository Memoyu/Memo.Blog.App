using Memo.Blog.App.Models.App;
using System.Diagnostics;

namespace Memo.Blog.App.Components.Components.Moment;

public partial class MomentList
{
    private List<SummaryCardItem> momentSummaries =
    [
        new SummaryCardItem ("动态数", "0"),
        new SummaryCardItem ("评论数", "0"),
        new SummaryCardItem ("浏览数", "0"),
        new SummaryCardItem ("浏览数", "0"),
        new SummaryCardItem ("浏览数", "0"),
        // new SummaryCardItem ("浏览数", "0")
    ];

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            Trace.WriteLine("动态第一次加载");
        }
    }

    private void ItemsChanged(List<SummaryCardItem> items)
    {
        
    }

    private void LoadMore()
    {
        //momentSummaries =
        //   [
        //       new SummaryCardItem ("动态数", "10"),
        //        new SummaryCardItem ("评论数", "20"),
        //        new SummaryCardItem ("浏览数", "30"),
        //         new SummaryCardItem ("测试", "30")
        //   ];
        momentSummaries[0].Value = "100";
        momentSummaries[1].Value = "30";
        momentSummaries[2].Value = "80";
    }
}
