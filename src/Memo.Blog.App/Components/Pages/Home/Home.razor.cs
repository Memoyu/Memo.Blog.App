using Masa.Blazor;
using Memo.Blog.App.Models.App;

namespace Memo.Blog.App.Components.Pages.Home
{
    public partial class Home
    {
        private StringNumber tab = 0;

        private readonly List<TabItem> tabItems = [
            new("概览","dashboard"),
            new("文章","article"),
            new("动态","moment"),
        ];

        private void SwiperIndexChanged(int index)
        {
            tab = index;
        }
    }
}
