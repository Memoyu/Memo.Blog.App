using Memo.Blog.App.Models.App;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Components;

public partial class BottomSheet
{
    [Parameter] public bool Cancel { get; set; } = true;

    [Parameter] public RenderFragment<ActivatorProps> ActivatorContent { get; set; } = default!;

    [Parameter] public List<SheetItem> SheetItems { get; set; } = [];

    public Dictionary<string, object> ActivatorAttributes { get; set; } = [];

    protected RenderFragment? ComputedActivatorContent(ActivatorProps props)
    {
        ActivatorAttributes = props.Attrs;
        if (ActivatorContent is null)
        {
            return null;
        }

        return ActivatorContent(props);
    }
}
