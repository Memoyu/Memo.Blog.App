using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Models.App;

public class SheetItem
{
    public string Title { get; set; } = string.Empty;

    public string Icon { get; set; } = string.Empty;

    public string Color { get; set; } = "primary";

    public bool Show { get; set; } = true;

    public EventCallback OnClick { get; set; }

    public SheetItem(object receiver, string title, string icon, Action onClick, string color = "primary", bool show = true)
    {
        Title = title;
        Icon = icon;
        Color = color;
        Show = show;
        OnClick = EventCallback.Factory.Create(receiver, onClick);
    }
}
