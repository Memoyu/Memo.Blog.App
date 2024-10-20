using Memo.Blog.App.Components.Base;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Pages.Article.Components;

public partial class SelectBannerDialog : DialogComponentBase
{
    [Parameter] public string Banner { get; set; } = string.Empty;
    [Parameter] public EventCallback<string> BannerChanged { get; set; }

    bool _preview = false;

    private async Task BeforeShowContent()
    {
    }

    private void HandleSelectImage()
    {
    }

    private async Task HandleSave()
    {
    }
}
