namespace Memo.Blog.App.Components.Pages.User.Setting;

public partial class ThemeMode
{
    // 0: Auto, 1: Light, 2: Dark
    private int theme;

    protected override void OnPageActivated(object? state)
    {
        // `state` 来自上一个页面调用 GoBack 时传递的参数
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            theme = await AppIntegrationService.GetThemeAsync();
            // StateHasChanged();
        }
    }

    private async Task AutoChanged(bool val)
    {
        if (val)
        {
            theme = 0;
        }
        else
        {
            var isDark = await AppIntegrationService.IsThemeOfSystemAsync();
            theme = isDark ? 2 : 1;
        }

        await AppIntegrationService.SetThemeAsync(theme);
    }

    private void ToggleTheme(StringNumber val)
    {
        var value = val.AsT1;
        theme = value;
        Console.Out.WriteLine("[DarkMode] Toggle theme: " + value);
        AppIntegrationService.SetThemeAsync(value);
    }
}
