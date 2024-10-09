using Masa.Blazor;
using Memo.Blog.App.Models.App;
using Microsoft.AspNetCore.Components;

namespace Memo.Blog.App.Components.Components;

public partial class SummaryCard
{
    private static int defaultColumns = 3;

    private int rows => Items.Count / columns;

    private int columns => Columns?.ToInt32() ?? defaultColumns;

    [Parameter] public StringNumber? Columns { get; set; } = defaultColumns;

    private List<SummaryCardItem> _items = [];
    [Parameter]
    public List<SummaryCardItem> Items
    {
        get => _items;
        set
        {
            if (_items == value) return;
            _items = value;
            ItemsChanged.InvokeAsync(value);
        }
    }

    [Parameter] public EventCallback<List<SummaryCardItem>> ItemsChanged { get; set; }
}
