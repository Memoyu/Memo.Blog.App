using Memo.Blog.App.Services.App;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Layout
{
    public partial class MainLayout
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        protected AppIntegrationService AppIntegrationService { get; set; } = default!;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await AppIntegrationService.InitThemeAsync();
            }
        }
    }
}
