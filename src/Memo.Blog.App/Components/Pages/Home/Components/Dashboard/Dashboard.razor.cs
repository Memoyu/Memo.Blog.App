
using Masa.Blazor;
using Memo.Blog.App.Models.App;
using System.Diagnostics;

namespace Memo.Blog.App.Components.Pages.Home.Components.Dashboard;

public partial class Dashboard
{
    private List<SummaryCardItem> _summaries =
    [
        new SummaryCardItem ("文章数", "0"),
        new SummaryCardItem ("动态数", "0"),
        new SummaryCardItem ("友链数", "0"),
        new SummaryCardItem ("UV", "0"),
        new SummaryCardItem ("PV", "0"),
        new SummaryCardItem ("评论", "0"),
    ];

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            Trace.WriteLine("概览第一次加载");
            await Task.CompletedTask;
        }
    }

    private async Task HandleOnRefreshAsync()
    {
    }
}
