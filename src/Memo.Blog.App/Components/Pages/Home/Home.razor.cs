using Masa.Blazor;
using Memo.Blog.App.Models.App;
using DashboardIndex = Memo.Blog.App.Components.Pages.Home.Components.Dashboard.Dashboard;
using ArticleIndex = Memo.Blog.App.Components.Pages.Home.Components.Article.Article;
using MomentIndex = Memo.Blog.App.Components.Pages.Home.Components.Moment.Moment;

namespace Memo.Blog.App.Components.Pages.Home
{
    public partial class Home
    {
        private readonly List<TabItem> tabItems = [
            new("概览","dashboard"),
            new("文章","article"),
            new("动态","moment"),
        ];

        private StringNumber tab = 0;
        private DashboardIndex? _dashboardRef;
        private ArticleIndex? _articleRef;
        private MomentIndex? _momentRef;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        private async Task SwiperIndexChanged(int index)
        {
            tab = index;

            var item = tabItems[index];
            if (item == null) return;
            if (item.IsInit) return;

            item.IsInit = true;
            switch (index)
            {
                case 1:
                    await (_articleRef?.InitAsync() ?? Task.CompletedTask);
                    break;
                case 2:
                    await (_momentRef?.InitAsync() ?? Task.CompletedTask);
                    break;
            }
        }
    }
}
