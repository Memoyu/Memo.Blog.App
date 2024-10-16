using Memo.Blog.App.Models.App;

namespace Memo.Blog.App.Components.Pages.Home.Components.Dashboard;

public partial class Dashboard
{
    private List<SummaryCardItem> _summaries =
    [
        new SummaryCardItem ("文章", "0"),
        new SummaryCardItem ("动态", "0"),
        new SummaryCardItem ("友链", "0"),
        new SummaryCardItem ("UV", "0"),
        new SummaryCardItem ("PV", "0"),
        new SummaryCardItem ("评论", "0"),
    ];

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await HandleOnRefreshAsync();
            StateHasChanged();
        }
    }

    private async Task HandleOnRefreshAsync()
    {
        // TODO：模拟数据加载
        await Task.Delay(1000);
        _summaries[0].Value = "100";
        _summaries[3].Value = "120";
    }
}
