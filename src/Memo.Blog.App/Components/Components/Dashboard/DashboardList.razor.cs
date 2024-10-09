
using System.Diagnostics;

namespace Memo.Blog.App.Components.Components.Dashboard;

public partial class DashboardList
{
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            Trace.WriteLine("概览第一次加载");
            await Task.CompletedTask;
        }
    }
}
